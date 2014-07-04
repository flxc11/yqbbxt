using CNVP.Framework.Utils;
using CNVP.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    public partial class ApplyEdit : UserPage
    {
        public string appState, appPage, applyGuid, applyId, scwId, mfile0_0, mfile0_1, mfile0_2, mfile0_3, mfile0_4 = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = Request.Params["Action"];
            switch (Action)
            {
                case "EditandApply":
                    EditApply(0);
                    break;
                case "Edit":
                    EditApply(2);
                    break;
            }
            if (!IsPostBack)
            {
                #region 当前页面赋值
                string guid = Request.Params["guid"];
                appState = Request.Params["State"];
                appPage = Request.Params["page"];
                if (!string.IsNullOrEmpty(guid))
                {
                    CNVP.UI.Application _apply = new UI.Application();
                    if (_apply.ApplyState(guid) != "2")
                    {
                        MessageBox.ShowMessage("申请单当前状态不允许编辑！", "ApplicationList.aspx?State=03c49c0a");

                    }
                    else
                    {
                        applyGuid = guid;
                        Hashtable ht = new Hashtable();
                        ht.Add("Guid", guid);
                        Model.Application appli = Model.Application.Instance.GetModelById(ht);
                        appli.SetWebControls(this.Page);
                        IO.SelectedValue = appli.IO.ToString();
                        applyId = appli.Id.ToString();
                        //安全适运单
                        if (appli.IO == 1)
                        {
                            ht.Clear();
                            ht.Add("AppGuid", guid);
                            Model.SCW scw = Model.SCW.Instance.GetModelById(ht);
                            scw.SetWebControls(this.Page);
                            GoodsGroup.SelectedValue = scw.GoodsGroup;
                            scwId = scw.Id.ToString();
                            string[] arr = scw.ExatrCertificate.Split(',');
                            for (int i = 0; i < arr.Length; i++)
                            {
                                ListItem li = ExatrCertificate.Items.FindByValue(arr[i]);
                                if (li != null)
                                {
                                    li.Selected = true;
                                }
                            }
                        }

                        //散装货物列表
                        Model.BulkFreight bulk = new Model.BulkFreight();
                        IList list = bulk.GetAllList(" and AppGuid='" + guid + "'", "Id");
                        rptBulk.DataSource = list;
                        rptBulk.DataBind();

                        //图片附件
                        mfile0_0 = GetImgUrl("mfile0_0", guid);
                        mfile0_1 = GetImgUrl("mfile0_1", guid);
                        mfile0_2 = GetImgUrl("mfile0_2", guid);
                        mfile0_3 = GetImgUrl("mfile0_3", guid);
                        mfile0_4 = GetImgUrl("mfile0_4", guid);
                    }
                    

                }
                #endregion
            }
        }

        #region 编辑申请单
        /// <summary>
        /// 编辑申请单
        /// </summary>
        private void EditApply(int editState)
        {
            string applyId = Request.Params["applyId"];
            string scwId = Request.Params["scwId"];
            string bulkId = Request.Params["bulkId"]; //散装货物表ID 不能传入string类型，新定义一个字段存入ID
            string applyGuid = Request.Params["applyGuid"];
            string appState = Request.Params["appState"];
            string appPage = Request.Params["appPage"];
            CNVP.UI.FileUpload upload = new UI.FileUpload();
            Model.Application appli = new Model.Application();
            Model.SCW scw = new Model.SCW();
            Model.Source source = new Model.Source();
            Model.BulkFreight bulk = new Model.BulkFreight();

            //项目申请单
            appli.UpdateModel();
            appli.Id = Convert.ToInt32(applyId);
            appli.IO = Convert.ToInt32(IO.SelectedValue);
            appli.AppState = editState;

            //安全适运单
            if (appli.IO == 1)
            {
                CNVP.UI.Application _apply = new UI.Application();
                scw.UpdateModel();
                scw.ExatrCertificate = _apply.GetCheck(ExatrCertificate, ",");
                scw.GoodsGroup = GoodsGroup.SelectedValue;
                scw.Id = Convert.ToInt32(scwId);
            }


            //附件上传
            source.AppGuid = applyGuid;
            //source.CreateTime = DateTime.Now;
            source.SourceUrl = upload.UploadPic();
            //source.UserId = Convert.ToInt32(UserLoginInfo.UserLoginID);

            //散装货物上传
            //bulk.Id = Request.Params["bulkId"];
            bulk.BfGoodsName = Request.Params["BfGoodsName"];
            bulk.BfGoodsGroup = Request.Params["BfGoodsGroup"];
            bulk.Class = Request.Params["Class"];
            bulk.DangerousNo = Request.Params["DangerousNo"];
            bulk.BfTotalWeight = Request.Params["BfTotalWeight"];
            bulk.DischargingPort = Request.Params["DischargingPort"];
            bulk.Position = Request.Params["Position"];
            bulk.Remark = Request.Params["Remark"];

            CNVP.Data.Application bll = new CNVP.Data.Application();
            bll.Edit(appli, scw, source, bulk, bulkId);

            MessageBox.ShowMessage("修改提交成功！", "ApplicationList.aspx?State=" + appState + "&page=" + appPage);
        }
        #endregion

        #region 判断散装货物所在组别
        //判断散装货物所在组别
        public string GoodsGroups(string groupName, string currentName)
        {
            string str = string.Empty;
            if (groupName == currentName)
            {
                str = "selected='selected'";
            }
            return str;
        }
        #endregion

        #region 根据上传类型获取附件地址
        /// <summary>
        /// 根据上传类型获取附件地址
        /// </summary>
        /// <param name="imgType">证件类型</param>
        /// <param name="guid">当前申请单guid</param>
        /// <returns></returns>
        private string GetImgUrl(string imgType, string guid)
        {
            string str = string.Empty;
            Model.Source source = new Model.Source();

            IList list = source.
                GetAllList(" and SourceType='" + imgType + "' and AppGuid='" + guid + "'", "Id");
            if (list != null)
            {
                foreach (Model.Source item in list)
                {
                    str = item.SourceUrl;
                }
            }
            

            return str;
        }
        #endregion
    }
}