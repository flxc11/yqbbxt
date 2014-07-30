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
    using System.Data;

    using CNVP.Framework.DataAccess;

    public partial class ApplyDetail : AdminPage
    {
        public string _appState, appPage, applyGuid, mfile0_0, mfile0_1, mfile0_2, mfile0_3, mfile0_4, scwmfile1, scwmfile2, scwmfile3, scwmfile4, strIO, imgsrc1, imgsrc2 = string.Empty;
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
                        strIO = "进港";
                        Panel1.Visible = false;
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
                    scwmfile2 = _fuplo.GetImgUrl("scwmfile0_2", guid);
                    scwmfile3 = _fuplo.GetImgUrl("scwmfile0_3", guid);
                    scwmfile4 = _fuplo.GetImgUrl("scwmfile0_4", guid);

                    //显示其它类型的附件
                    //申报单
                    string strsql1 = "select * from cnvp_source where appGuid='" + guid + "' and sourcetype like 'mfile0_%' and substring(sourcetype,8,2) > 4";
                    Model.Source source = new Model.Source();
                    DataTable dt3 = DataFactory.GetInstance().ExecuteTable(strsql1);
                    if (dt3.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            this.imgsrc1 += "<a href='" + dt3.Rows[i]["SourceUrl"] + "' target='_blank'>其它" + (i + 1) + "</a>&nbsp;&nbsp;";
                        }
                    }

                    // 适运单
                    string strsql2 = "select * from cnvp_source where appGuid='" + guid + "' and sourcetype like 'scwmfile0_%' and substring(sourcetype,11,2) > 3";
                    Model.Source source1 = new Model.Source();
                    DataTable dt4 = DataFactory.GetInstance().ExecuteTable(strsql2);
                    if (dt4.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt4.Rows.Count; i++)
                        {
                            this.imgsrc2 += "<a href='" + dt4.Rows[i]["SourceUrl"] + "' target='_blank'>其它" + (i + 1) + "</a>&nbsp;&nbsp;";
                        }
                    }

                    if (_fuplo.GetImgUrl("mfile0_3", guid) != "")
                    {
                        mfile0_3 = "4、<a href=\"" + _fuplo.GetImgUrl("mfile0_3", guid) + "\" target=\"_blank\">进/出港申报委托书</a>&nbsp;&nbsp;";
                    }
                    if (_fuplo.GetImgUrl("mfile0_3", guid) != "")
                    {
                        mfile0_4 = "5、<a href=\"" + _fuplo.GetImgUrl("mfile0_4", guid) + "\" target=\"_blank\">保险证书类型</a>&nbsp;&nbsp;";
                    }
                    if (_fuplo.GetImgUrl("scwmfile0_1", guid) != "")
                    {
                        scwmfile1 = "<a href=\"" + _fuplo.GetImgUrl("scwmfile0_1", guid) + "\" target=\"_blank\">水份含量和适运水份极限证书</a>&nbsp;&nbsp;";
                    }
                    if (_fuplo.GetImgUrl("scwmfile0_2", guid) != "")
                    {
                        scwmfile2 = "<a href=\"" + _fuplo.GetImgUrl("scwmfile0_1", guid) + "\" target=\"_blank\">安全适运性评估报告</a>&nbsp;&nbsp;";
                    }
                    if (_fuplo.GetImgUrl("scwmfile0_3", guid) != "")
                    {
                        scwmfile3 = "<a href=\"" + _fuplo.GetImgUrl("scwmfile0_3", guid) + "\" target=\"_blank\">委托书</a>&nbsp;&nbsp;";
                    }
                    if (_fuplo.GetImgUrl("scwmfile0_4", guid) != "")
                    {
                        scwmfile4 = "<a href=\"other.aspx?AppGuid=" + applyGuid + "\" target=\"_blank\">其它</a>";
                    }

                    //审批意见信息

                    Model.Accredit accredit = Model.Accredit.Instance.GetModelById(ht);
                    AppOpinions.Text = accredit.AppOpinions;
                    ScwOpinions.Text = accredit.ScwOpinions;

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

            Hashtable ht = new Hashtable();
            ht.Add("Guid", guid);
            Model.Application appli = Model.Application.Instance.GetModelById(ht);
            Model.SCW scw = new Model.SCW();
            if (appli.IO == 1)
            {
                Model.PrintNum printNum = new Model.PrintNum();
                using (DataTable dt = CNVP.Framework.DataAccess.DataFactory.GetInstance().ExecuteTable("select max(ApplyNum) as maxA from CNVP_PrintNum"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int maxANum = Convert.ToInt32(dt.Rows[0]["maxA"].ToString()) + 1;
                        printNum.Update("ApplyNum=" + maxANum, string.Empty);
                        apply.Update("PrintNum=" + maxANum, " and Guid='" +
                    guid + "'");
                    }
                }
                using (DataTable dt1 = CNVP.Framework.DataAccess.DataFactory.GetInstance().ExecuteTable("select max(ScwNum) as maxS from CNVP_PrintNum"))
                {
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        int maxSNum = Convert.ToInt32(dt1.Rows[0]["maxS"].ToString()) + 1;
                        printNum.Update("ScwNum=" + maxSNum, string.Empty);
                        scw.Update("PrintNum=" + maxSNum, " and AppGuid='" +
                    guid + "'");
                    }
                }
            }
            else
            {
                Model.PrintNum printNum = new Model.PrintNum();
                using (DataTable dt = CNVP.Framework.DataAccess.DataFactory.GetInstance().ExecuteTable("select max(ApplyNum) as maxA from CNVP_PrintNum"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int maxANum = Convert.ToInt32(dt.Rows[0]["maxA"].ToString()) + 1;
                        printNum.Update("ApplyNum=" + maxANum, string.Empty);
                        apply.Update("PrintNum=" + maxANum, " and Guid='" +
                    guid + "'");
                    }
                }
            }

            //修改申请单状态
            if (!string.IsNullOrEmpty(guid))
            {
                apply.Update("AppState=" + applyState, " and Guid='" +
                    guid + "'");
                if (_appState == "1")
                {
                    if (appli.IO == 1)
                    {
                        strIO = "出港";
                    }
                    else
                    {
                        strIO = "进港";
                        Panel1.Visible = false;
                    }
                }
            }

            //增加或修改审批意见
            CNVP.UI.Application _apply = new Application();
            if (_apply.IsOpinionExist(guid))
            {
                accredit.Update("AppOpinions='" + AppOpinions.Text + "', ScwOpinions='" + ScwOpinions.Text + "'"," and AppGuid='" + guid + "'");
            }
            else
            {
                accredit.AccreditationMen = Convert.ToInt32(LoginInfo.LoginID);
                accredit.AccreditationTime = DateTime.Now;
                accredit.AppGuid = guid;
                accredit.Guid = Public.GetGuID;
                accredit.AppOpinions = AppOpinions.Text;
                accredit.ScwOpinions = ScwOpinions.Text;
                accredit.Insert(accredit);
            }
            
            MessageBox.ShowMessage("审批成功！", "ApplyList.aspx?State=" + _appState + "&page=" + appPage);
        }
        #endregion
    }
}