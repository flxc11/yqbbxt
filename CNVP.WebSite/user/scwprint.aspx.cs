using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using System.Collections;
    using System.Data;

    using CNVP.Framework.DataAccess;
    using CNVP.Framework.Utils;

    public partial class scwprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AppGuid = Request.Params["AppGuid"];

            if (!string.IsNullOrEmpty(AppGuid))
            {
                string content = FileUtils.ReadFile(Server.MapPath("~/Template/scw.htm"));
                Hashtable ht = new Hashtable();
                ht.Add("AppGuid", AppGuid);
                Model.SCW scw = Model.SCW.Instance.GetModelById(ht);
                Model.Accredit accredit = Model.Accredit.Instance.GetModelById(ht);
                content =
                    content.Replace("{#GoodsName}", scw.GoodsName)
                        .Replace("{#GoodsName}", scw.GoodsName)
                        .Replace("{#Shipper}", scw.Shipper)
                        .Replace("{#TransportDocNo}", scw.TransportDocNo)
                        .Replace("{#Consignee}", scw.Consignee)
                        .Replace("{#Carrier}", scw.Carrier)
                        .Replace("{#TransPort}", scw.TransPort)
                        .Replace("{#Guide}", scw.Guide)
                        .Replace("{#HomePort}", scw.HomePort)
                        .Replace("{#DestinationPort}", scw.DestinationPort)
                        .Replace("{#Description}", scw.Description)
                        .Replace("{#TotalWeight}", scw.TotalWeight)
                        .Replace("{#MoistureLimit}", scw.MoistureLimit)
                        .Replace("{#ParticularNature}", scw.ParticularNature)
                        .Replace("{#GoodsGroup1}", scw.GoodsGroup == "A组" ? "☑" : "□")
                        .Replace("{#GoodsGroup2}", scw.GoodsGroup == "C组" ? "☑" : "□");

                Model.Source source = new Model.Source();
                string scwmfile0 = "□";
                string scwmfile4 = "□";
                IList list = source.GetAllList(" and AppGuid='" + AppGuid + "' and SourceType='scwmfile0_1'", "Id");
                if (list != null)
                {
                    scwmfile0 = "☑";
                }

                string strsql = "select * from cnvp_source where appGuid='" + AppGuid + "' and sourcetype like 'scwmfile0_%' and substring(sourcetype,11,2) > 3";
                DataTable dt = DataFactory.GetInstance().ExecuteTable(strsql);
                if (dt.Rows.Count > 0)
                {
                    scwmfile4 = "☑";
                }

                content = content.Replace("{#ExatrCertificate1}", scwmfile0).Replace("{#ExatrCertificate2}", scwmfile4);

                //审批意见

                if (accredit != null)
                {
                    string xh = string.Empty;
                    if (scw.PrintNum.Length == 1)
                    {
                        xh = DateTime.Now.ToString("yyyyMMdd") + "0" + scw.PrintNum;
                    }
                    else
                    {
                        xh = scw.PrintNum;
                    }
                    content = content.Replace("{#spyj}", "准予备查");
                    content = content.Replace("{#spsj}", xh);
                }

                Response.Write(content);
            }
        }
    }
}