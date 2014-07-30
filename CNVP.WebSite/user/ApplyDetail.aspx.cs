using CNVP.Framework.DataAccess;
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
    public partial class ApplyDetail : UserPage
    {
        public string applyGuid, applyId, scwId, mfile0_0, mfile0_1, mfile0_2, mfile0_3, mfile0_4, mfile0_5, scwmfile1, scwmfile2, scwmfile3, scwmfile4, strIO, spyj, spyj1, printApply, printScw, printNotice, imgsrc1, imgsrc2 = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 当前页面赋值
                string guid = Request.Params["guid"];
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
                    if (appli.AppState == 1)
                    {
                        printApply = "<a href=\"solidbulk.aspx?AppGuid=" + guid + "\" target=\"_blank\">打印固体散装货物申报单</a>";
                        printScw = "<a href=\"scwprint.aspx?AppGuid=" + guid + "\" target=\"_blank\">打印安全适运申报单</a>";
                        printNotice = "<a href=\"Notice.aspx?AppGuid=" + guid + "\" class=\"btn-submit\" target=\"_blank\">打印审批通知单</a>";
                    }
                    applyId = appli.Id.ToString();
                    //安全适运单
                    ht.Clear();
                    ht.Add("AppGuid", guid);
                    Model.SCW scw = Model.SCW.Instance.GetModelById(ht);
                    scw.SetWebControls(this.Page);
                    scwId = scw.Id.ToString();

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
                    if (_fuplo.GetImgUrl("mfile0_3", guid) != "")
                    {
                        mfile0_3 = "4、<a href=\"" + _fuplo.GetImgUrl("mfile0_3", guid) + "\" target=\"_blank\">进/出港申报委托书</a>&nbsp;&nbsp;";
                    }
                    if (_fuplo.GetImgUrl("mfile0_4", guid) != "")
                    {
                        mfile0_4 = "5、<a href=\"" + _fuplo.GetImgUrl("mfile0_4", guid) + "\" target=\"_blank\">保险证书类型</a>&nbsp;&nbsp;";
                    }
                    //显示其它类型的附件
                    //申报单
                    string strsql1 = "select * from cnvp_source where appGuid='" + guid + "' and sourcetype like 'mfile0_%' and substring(sourcetype,8,2) > 4";
                    Model.Source source = new Model.Source();
                    DataTable dt = DataFactory.GetInstance().ExecuteTable(strsql1);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            this.imgsrc1 += "<a href='" + dt.Rows[i]["SourceUrl"] + "' target='_blank'>其它" + (i + 1) + "</a>&nbsp;&nbsp;";
                        }
                    }

                    // 适运单
                    string strsql2 = "select * from cnvp_source where appGuid='" + guid + "' and sourcetype like 'scwmfile0_%' and substring(sourcetype,11,2) > 3";
                    Model.Source source1 = new Model.Source();
                    DataTable dt1 = DataFactory.GetInstance().ExecuteTable(strsql2);
                    if (dt1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            this.imgsrc2 += "<a href='" + dt1.Rows[i]["SourceUrl"] + "' target='_blank'>其它" + (i + 1) + "</a>&nbsp;&nbsp;";
                        }
                    }

                    if (_fuplo.GetImgUrl("scwmfile0_1", guid) != string.Empty)
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
                    //if (_fuplo.GetImgUrl("scwmfile0_4", guid) != "")
                    //{
                    //    scwmfile4 = "<a href=\"other.aspx?AppGuid=" + applyGuid + "\" target=\"_blank\">其它</a>";
                    //}

                    #region 审批意见
                    DataTable dts1 = DataFactory.GetInstance().ExecuteTable("select * from CNVP_accredit where AppGuid='" + guid + "'");
                    if (dts1 != null && dts1.Rows.Count > 0)
                    {
                        spyj = dts1.Rows[0]["AppOpinions"].ToString();
                        spyj1 = dts1.Rows[0]["ScwOpinions"].ToString();
                    }
                    #endregion
                }
                #endregion
            }
        }

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
    }
}