using CNVP.Framework.Utils;
using CNVP.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.admin
{
    public partial class ApplyDetail : AdminPage
    {
        public string _appState, appPage, applyGuid, mfile0_0, mfile0_1, mfile0_2, mfile0_3, mfile0_4, strIO = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = Request.Params["Action"];
            switch (Action)
            {
                case "EditState":
                    EditState();
                    break;
            }
            if (!IsPostBack)
            {
                #region 当前页面赋值
                string guid = Request.Params["guid"];
                _appState = Request.Params["State"];
                appPage = Request.Params["page"];
                if (!string.IsNullOrEmpty(guid))
                {
                    applyGuid = guid;
                    Hashtable ht = new Hashtable();
                    ht.Add("Guid", guid);
                    Model.Application appli = Model.Application.Instance.GetModelById(ht);
                    appli.SetWebControls(this.Page);
                    this.ArrivedTime.Text = Convert.ToDateTime(appli.ArrivedTime).ToString("yyyy-MM-dd");
                    this.WorkTime.Text = Convert.ToDateTime(appli.WorkTime).ToString("yyyy-MM-dd");
                    if (appli.IO == 1)
                    {
                        strIO = "出港";
                    }
                    else
                    {
                        strIO = "入港";
                    }
                    AppState.SelectedValue = appli.AppState.ToString();
                    //安全适运单
                    ht.Clear();
                    ht.Add("AppGuid", guid);
                    Model.SCW scw = Model.SCW.Instance.GetModelById(ht);
                    scw.SetWebControls(this.Page);

                    //散装货物列表
                    Model.BulkFreight bulk = new Model.BulkFreight();
                    IList list = bulk.GetAllList(" and AppGuid='" + guid + "'", "Id");
                    rptBulk.DataSource = list;
                    rptBulk.DataBind();

                    //图片附件
                    CNVP.UI.FileUpload _fuplo = new UI.FileUpload();
                    mfile0_0 = _fuplo.GetImgUrl("mfile0_0", guid);
                    mfile0_1 = _fuplo.GetImgUrl("mfile0_1", guid);
                    mfile0_2 = _fuplo.GetImgUrl("mfile0_2", guid);
                    mfile0_3 = _fuplo.GetImgUrl("mfile0_3", guid);
                    mfile0_4 = _fuplo.GetImgUrl("mfile0_4", guid);

                    //审批意见信息
                    Model.Accredit accredit = Model.Accredit.Instance.GetModelById(ht);
                    AppOpinions.Text = accredit.AppOpinions;

                }
                #endregion
            }
        }

        #region 更新申请单状态
        /// <summary>
        /// 更新申请单状态
        /// </summary>
        private void EditState()
        {
            string guid = Request.Params["applyGuid"];
            string applyState = AppState.SelectedValue;
            _appState = Request.Params["applyState"];
            appPage = Request.Params["appPage"];
            Model.Application apply = new Model.Application();
            Model.Accredit accredit = new Model.Accredit();

            //修改申请单状态
            if (!string.IsNullOrEmpty(guid))
            {
                apply.Update("AppState=" + applyState, " and Guid='" +
                    guid + "'");
            }

            //增加或修改审批意见
            CNVP.UI.Application _apply = new Application();
            if (_apply.IsOpinionExist(guid))
            {
                accredit.Update("AppOpinions='" + AppOpinions.Text + "'", " and AppGuid='" +
                    guid + "'");
            }
            else
            {
                accredit.AccreditationMen = Convert.ToInt32(LoginInfo.LoginID);
                accredit.AccreditationTime = DateTime.Now;
                accredit.AppGuid = guid;
                accredit.Guid = Public.GetGuID;
                accredit.AppOpinions = AppOpinions.Text;
                accredit.Insert(accredit);
            }
            
            MessageBox.ShowMessage("审批申报成功！", "ApplyList.aspx?State=" + _appState + "&page=" + appPage);
        }
        #endregion
    }
}