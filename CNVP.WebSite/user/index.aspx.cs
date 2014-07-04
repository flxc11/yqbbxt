using CNVP.Framework.Utils;
using CNVP.UI;
using CNVP.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    public partial class index : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = Request.Params["Action"];
            switch (Action)
            {
                case "Application":
                    Application();
                    break;
            }
        }

        #region 提交申请
        /// <summary>
        /// 提交申请
        /// </summary>
        private void Application()
        {
            CNVP.UI.FileUpload upload = new UI.FileUpload();
            Model.Application appli = new Model.Application();
            Model.SCW scw = new Model.SCW();
            Model.Source source = new Model.Source();
            Model.BulkFreight bulk = new Model.BulkFreight();

            //项目申请单
            appli.UpdateModel();
            appli.CreateTime = DateTime.Now;
            appli.AppState = 0;
            appli.Guid = Public.GetGuID;
            appli.UserId = Convert.ToInt32(UserLoginInfo.UserLoginID);

            //安全适运单
            if (appli.IO == 1)
            {
                CNVP.UI.Application _apply = new UI.Application();
                scw.UpdateModel();
                scw.AppGuid = appli.Guid;
                scw.ExatrCertificate = _apply.GetCheck(ExatrCertificate, ",");
                scw.CreateTime = DateTime.Now;
            }

            //附件上传
            source.AppGuid = appli.Guid;
            source.CreateTime = DateTime.Now;
            source.SourceUrl = upload.UploadPic();
            source.UserId = Convert.ToInt32(UserLoginInfo.UserLoginID);

            //散装货物上传
            bulk.AppGuid = appli.Guid;
            bulk.BfGoodsName = Request.Params["BfGoodsName"];
            bulk.BfGoodsGroup = Request.Params["BfGoodsGroup"];
            bulk.Class = Request.Params["Class"];
            bulk.DangerousNo = Request.Params["DangerousNo"];
            bulk.BfTotalWeight = Request.Params["BfTotalWeight"];
            bulk.DischargingPort = Request.Params["DischargingPort"];
            bulk.Position = Request.Params["Position"];
            bulk.Remark = Request.Params["Remark"];

            CNVP.Data.Application bll = new CNVP.Data.Application();
            bll.Add(appli, scw, source, bulk);

            MessageBox.ShowMessage("申请提交成功！", "ApplicationList.aspx?State=30dbfa02897d3c");
        }
        #endregion
    }
}