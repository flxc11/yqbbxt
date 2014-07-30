using CNVP.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    public partial class other : System.Web.UI.Page
    {
        public string imgsrc = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string appGuid = Request.Params["AppGuid"];
                string imgtype = Request.Params["imgtype"];
                string strsql = string.Empty;
                if (!string.IsNullOrEmpty(appGuid))
                {
                    if (imgtype == "1")
                    {
                        strsql = "select * from cnvp_source where appGuid='" + appGuid + "' and sourcetype like 'mfile0_%' and substring(sourcetype,8,2) > 4";
                    }
                    else
                    {
                        strsql = "select * from cnvp_source where appGuid='" + appGuid + "' and sourcetype like 'scwmfile0_%' and substring(sourcetype,11,2) > 3";
                    }
                    Model.Source source = new Model.Source();
                    DataTable dt = DataFactory.GetInstance().
                        ExecuteTable(strsql);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            imgsrc += "<p><a href='" + dt.Rows[i]["SourceUrl"] + "' target='_blank'>其它" + (i + 1) + "</a></p>";
                        }
                    }
                }
            }
        }
    }
}