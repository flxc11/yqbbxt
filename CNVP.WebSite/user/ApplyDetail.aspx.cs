using CNVP.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    public partial class ApplyDetail : UserPage
    {
        public string applyGuid, applyId, scwId, mfile0_0, mfile0_1, mfile0_2, mfile0_3, mfile0_4, strIO = string.Empty;
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
                        strIO = "入港";
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
                    mfile0_3 = _fuplo.GetImgUrl("mfile0_3", guid);
                    mfile0_4 = _fuplo.GetImgUrl("mfile0_4", guid);
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