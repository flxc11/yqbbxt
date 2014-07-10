using CNVP.Config;
using CNVP.Framework.DataAccess;
using CNVP.Framework.Helper;
using CNVP.Framework.Utils;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.admin
{
    public partial class adminjson : System.Web.UI.Page
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
                case "Addmanager":
                    Addmanager();
                    break;
                case "GetManagerList":
                    GetManagerList();
                    break;
                case "UpdateManager":
                    UpdateManager();
                    break;
                case "ResetManagerPass":
                    ResetManagerPass();
                    break;
                case "DeleteManager":
                    DeleteManager();
                    break;
                case "Export":
                    Export();
                    break;
                default:
                    break;
            }
        }

        #region 添加管理员账号
        private void Addmanager()
        {

        }
        #endregion
        #region 账号列表
        private void GetManagerList()
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
            sqlWhere = UIConfig.Prefix + "Admin where 1=1 ";
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

        #region 更新管理员信息
        private void UpdateManager()
        {
            string Id = Public.FilterSql(Request.Params["Id"]);
            string UserEmail = Request.Params["UserEmail"];
            string TrueName = Request.Params["TrueName"];
            string UserTel = Request.Params["UserTel"];
            string UserUnit = Request.Params["UserUnit"];
            Model.Admin user = new Model.Admin();
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

        #region 管理员密码重置
        private void ResetManagerPass()
        {
            string Id = Public.FilterSql(Request.Params["Id"]);
            string userPass = Request.Params["UserPass"];
            Model.Admin user = new Model.Admin();
            user.Id = Convert.ToInt32(Id);
            user.UserPass = Encrypt.Md5(userPass);
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

        #region 删除管理员信息
        private void DeleteManager()
        {
            string Id = Public.FilterSql(Request.Params["Id"]);
            Model.Admin user = new Model.Admin();
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

        #region 数据导出
        private void Export()
        {
            string state = Request.Params["State"];
            string _startTime = Request.Params["StartTime"];
            string _endTime = Request.Params["EndTime"];
            string _selectType = Request.Params["SelectType"];
            string _keyword = Request.Params["Keyword"];
            string sqlWhere = string.Empty;
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
            DataTable dt = DataFactory.GetInstance().ExecuteTable("select * from " + sqlWhere + " order by createtime desc");

            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            sheet.CreateRow(0).CreateCell(0).SetCellValue("进/出港");         //第一行需要生成，
            sheet.GetRow(0).CreateCell(1).SetCellValue("船名");       //第一行第二列只需要使用 GetRow就可以，因为上面已经生成了第一行。 
            sheet.GetRow(0).CreateCell(2).SetCellValue("航次");
            sheet.GetRow(0).CreateCell(3).SetCellValue("经营人");
            sheet.GetRow(0).CreateCell(4).SetCellValue("始发港");
            sheet.GetRow(0).CreateCell(5).SetCellValue("抵港时间");
            sheet.GetRow(0).CreateCell(6).SetCellValue("作业泊位");
            sheet.GetRow(0).CreateCell(7).SetCellValue("状态");
            sheet.GetRow(0).CreateCell(8).SetCellValue("申请时间");

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sheet.CreateRow(i + 1).CreateCell(0).SetCellValue(dt.Rows[i]["IO"].ToString() == "1" ? "出港" : "入港");
                    sheet.GetRow(i + 1).CreateCell(1).SetCellValue(dt.Rows[i]["ShipName"].ToString());
                    sheet.GetRow(i + 1).CreateCell(2).SetCellValue(dt.Rows[i]["Saillings"].ToString());
                    sheet.GetRow(i + 1).CreateCell(3).SetCellValue(dt.Rows[i]["Operator"].ToString());
                    sheet.GetRow(i + 1).CreateCell(4).SetCellValue(dt.Rows[i]["StartPort"].ToString());
                    sheet.GetRow(i + 1).CreateCell(5).SetCellValue(Convert.ToDateTime(dt.Rows[i]["ArrivedTime"].ToString()).ToString("yyyy-MM-dd"));
                    sheet.GetRow(i + 1).CreateCell(6).SetCellValue(dt.Rows[i]["WorkBerth"].ToString());
                    sheet.GetRow(i + 1).CreateCell(7).SetCellValue(ApplyState(dt.Rows[i]["AppState"].ToString()));
                    sheet.GetRow(i + 1).CreateCell(8).SetCellValue(Convert.ToDateTime(dt.Rows[i]["CreateTime"].ToString()).ToString("yyyy-MM-dd"));
                }
            }
            workbook.Write(ms);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Export.xls"));
            Response.BinaryWrite(ms.ToArray());
            workbook = null;
            ms.Close();
            ms.Dispose();
        }
        #endregion

        #region 审批单状态
        private string ApplyState(string AppState)
        {
            switch (AppState)
            {
                case "0":
                    return "待审批";
                    break;
                case "1":
                    return "已审批";
                    break;
                case "2":
                    return "待审批";
                    break;
                case "3":
                    return "不予备案";
                    break;
                default:
                    return "待审批";
                    break;
            }
        }
        #endregion

    }
}