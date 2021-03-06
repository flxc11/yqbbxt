﻿using CNVP.Config;
using CNVP.Framework.DataAccess;
using CNVP.Framework.Helper;
using CNVP.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using System.Collections;

    public partial class userjson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            string Action = Request.Params["action"];

            switch (Action)
            {
                case "GetApplyList":
                    this.GetApplyList();
                    break;
                case "Delete":
                    this.Delete();
                    break;
                case "GetUserList":
                    this.GetUserList();
                    break;
                case "UpdateUser":
                    this.UpdateUser();
                    break;
                case "ResetUserPass":
                    this.ResetUserPass();
                    break;
                case "DeleteUser":
                    this.DeleteUser();
                    break;
                case "ApplySearch":
                    this.ApplySearch();
                    break;
                case "FileDelete":
                    this.FileDelete();
                    break;
                default:
                    break;
            }
        }

        #region 项目申请列表
        /// <summary>
        /// 项目申请列表
        /// </summary>
        private void GetApplyList()
        {
            string pageIndex = Request.Params["Page"];
            string state = Request.Params["State"];
            string sqlWhere = string.Empty;
            string userId = Request.Params["userId"];
            if (string.IsNullOrEmpty(pageIndex) || !Public.IsNumber(pageIndex))
            {
                pageIndex = "1";
            }
            string pageSize = Request.Params["Rows"];
            if (string.IsNullOrEmpty(pageSize) || !Public.IsNumber(pageSize))
            {
                pageIndex = "10";
            }
            sqlWhere = UIConfig.Prefix + "Application where 1=1 ";
            if (!string.IsNullOrEmpty(state) && Public.IsNumber(state))
            {
                sqlWhere += " and AppState=" + state;
            }
            if (!string.IsNullOrEmpty(userId) && Public.IsNumber(userId))
            {
                sqlWhere += " and UserID=" + userId;
            }
            int recordCount = 0;
            int pageCount = 0;

            //string strSql = "select  * from " + UIConfig.Prefix + "Application order by createtime desc";

            DataTable dt = DataFactory.GetInstance().ExecutePage("*",
                sqlWhere, "Id", "Id desc", Convert.ToInt32(pageIndex), Convert.ToInt32(pageSize), ref recordCount, ref pageCount);
            string easyGrid_Sort = Request.Params["easyGrid_Sort"];

            string str = JsonHelper.EasyGridTable(dt, easyGrid_Sort, recordCount);
            Response.Write(str);
            Response.End();
        }
        #endregion

        #region 删除申请表
        private void Delete()
        {
            string guidList = Request.Params["Guid"];
            string rslt = string.Empty;
            if (!string.IsNullOrEmpty(guidList))
            {
                Model.Application apply = new Model.Application();
                Model.BulkFreight bulk = new Model.BulkFreight();
                Model.SCW scw = new Model.SCW();
                string[] guid = guidList.Split(',');
                foreach (var item in guid)
                {
                    apply.Guid = item;
                    bulk.AppGuid = item;
                    scw.AppGuid = item;

                    try
                    {
                        CNVP.Data.Application bll = new CNVP.Data.Application();
                        bll.ApplyDelete(apply, scw, bulk);
                        rslt = "1";
                    }
                    catch (Exception e)
                    {
                        rslt = "0";
                    }
                    finally
                    {
                        
                    }
                }
                Response.Write("{\"result\":\"" + rslt + "\"}");
                Response.End();
            }
        }
        #endregion

        #region 注册用户列表
        /// <summary>
        /// 注册用户列表
        /// </summary>
        private void GetUserList()
        {
            string pageIndex = Request.Params["Page"];
            string sqlWhere = string.Empty;
            if (string.IsNullOrEmpty(pageIndex) || !Public.IsNumber(pageIndex))
            {
                pageIndex = "1";
            }
            string pageSize = Request.Params["Rows"];
            if (string.IsNullOrEmpty(pageSize) || !Public.IsNumber(pageSize))
            {
                pageIndex = "10";
            }
            sqlWhere = UIConfig.Prefix + "User where 1=1 ";
            int recordCount = 0;
            int pageCount = 0;
            //string strSql = "select  * from " + UIConfig.Prefix + "Application order by createtime desc";
            DataTable dt = DataFactory.GetInstance().ExecutePage("*",
                sqlWhere, "Id", "Id desc", Convert.ToInt32(pageIndex), Convert.ToInt32(pageSize), ref recordCount, ref pageCount);
            string easyGrid_Sort = Request.Params["easyGrid_Sort"];

            string str = JsonHelper.EasyGridTable(dt, easyGrid_Sort, recordCount);
            Response.Write(str);
            Response.End();
        }
        #endregion

        #region 更新注册用户
        /// <summary>
        /// 更新注册用户
        /// </summary>
        private void UpdateUser()
        {
            string Id = Public.FilterSql(Request.Params["Id"]);
            string UserEmail = Request.Params["UserEmail"];
            string TrueName = Request.Params["TrueName"];
            string UserTel = Request.Params["UserTel"];
            string UserUnit = Request.Params["UserUnit"];
            Model.User user = new Model.User();
            user.Id = Convert.ToInt32(Id);
            user.UserEmail = UserEmail;
            user.TrueName = TrueName;
            user.UserTel = UserTel;
            user.UserUnit = UserUnit;
            if (user.Update() == 1)
            {
                Response.Write("{\"returnval\":\"1\"}");
            }
            else
            {
                Response.Write("{\"returnval\":\"0\"}");
            }
            Response.End();            
        }
        #endregion

        #region 重置用户密码为888888
        private void ResetUserPass()
        {
            string Id = Public.FilterSql(Request.Params["Id"]);
            string userPass = Encrypt.Md5("888888");
            Model.User user = new Model.User();
            user.Id = Convert.ToInt32(Id);
            user.UserPass = userPass;
            if (user.Update() == 1)
            {
                Response.Write("{\"returnval\":\"1\"}");
            }
            else
            {
                Response.Write("{\"returnval\":\"0\"}");
            }
            Response.End();
        }
        #endregion

        #region 删除注册用户
        /// <summary>
        /// 删除注册用户
        /// </summary>
        private void DeleteUser()
        {
            string Id = Public.FilterSql(Request.Params["Id"]);
            Model.User user = new Model.User();
            user.Id = Convert.ToInt32(Id);
            if (user.Delete(Id) == 1)
            {
                Response.Write("{\"returnval\":\"1\"}");
            }
            else
            {
                Response.Write("{\"returnval\":\"0\"}");
            }
            Response.End();
        }
        #endregion

        #region 搜索列表
        private void ApplySearch()
        {
            string pageIndex = Request.Params["Page"];
            string state = Request.Params["State"];
            string _startTime = Request.Params["StartTime"];
            string _endTime = Request.Params["EndTime"];
            string _selectType = Request.Params["SelectType"];
            string _keyword = Request.Params["Keyword"];
            string sqlWhere = string.Empty;
            string userId = Request.Params["userId"];
            if (string.IsNullOrEmpty(pageIndex) || !Public.IsNumber(pageIndex))
            {
                pageIndex = "1";
            }
            string pageSize = Request.Params["Rows"];
            if (string.IsNullOrEmpty(pageSize) || !Public.IsNumber(pageSize))
            {
                pageIndex = "10";
            }
            sqlWhere = UIConfig.Prefix + "Application where 1=1 ";
            if (!string.IsNullOrEmpty(state) && Public.IsNumber(state))
            {
                sqlWhere += " and AppState=" + state;
            }
            if (!string.IsNullOrEmpty(_startTime) && !string.IsNullOrEmpty(_endTime))
            {
                sqlWhere += " and CreateTime between '" + _startTime + "' and '" + _endTime + "'";
            }
            if (!string.IsNullOrEmpty(_selectType))
            {
                if (_selectType == "1" || _selectType == "0")
                {
                    sqlWhere += " and IO=" + _selectType;
                }
                else
                {
                    sqlWhere += " and " + _selectType + " like '%" + _keyword + "%'";
                }
            }
            if (!string.IsNullOrEmpty(userId) && Public.IsNumber(userId))
            {
                sqlWhere += " and UserID=" + userId;
            }
            int recordCount = 0;
            int pageCount = 0;

            //string strSql = "select  * from " + UIConfig.Prefix + "Application order by createtime desc";

            DataTable dt = DataFactory.GetInstance().ExecutePage("*",
                sqlWhere, "Id", "Id desc", Convert.ToInt32(pageIndex), Convert.ToInt32(pageSize), ref recordCount, ref pageCount);
            string easyGrid_Sort = Request.Params["easyGrid_Sort"];

            string str = JsonHelper.EasyGridTable(dt, easyGrid_Sort, recordCount);
            Response.Write(str);
            Response.End();
        }
        #endregion

        #region 删除 附件信息
        /// <summary>
        /// 删除 附件信息
        /// </summary>
        private void FileDelete()
        {
            string appGuid = Request.Params["appGuid"];
            string sourceType = Request.Params["sourceType"];

            Model.Source source = new Model.Source();
            Hashtable ht = new Hashtable();
            ht.Add("AppGuid", appGuid);
            ht.Add("SourceType", sourceType);

            int num = source.Delete(ht);
            if (num > 0)
            {
                Response.Write("{\"result\":\"1\"}");
            }
            else
            {
                Response.Write("{\"result\":\"0\"}");
            }
            Response.End();
        }
        #endregion
    }
}