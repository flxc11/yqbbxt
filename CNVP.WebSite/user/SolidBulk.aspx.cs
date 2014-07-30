using CNVP.Framework.DataAccess;
using CNVP.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using System.Collections;

    public partial class SolidBulk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bulkList = string.Empty;
            string AppGuid = Request.Params["AppGuid"];
            if (!string.IsNullOrEmpty(AppGuid))
            {
                string content = FileUtils.ReadFile(Server.MapPath("~/Template/SolidBulk.htm"));
                Hashtable ht = new Hashtable();
                ht.Add("Guid", AppGuid);
                Hashtable ht1 = new Hashtable();
                ht1.Add("AppGuid", AppGuid);
                Model.Application apply = Model.Application.Instance.GetModelById(ht);
                Model.Accredit accredit = Model.Accredit.Instance.GetModelById(ht1);
                content = content.Replace("{#ShipName}", GetStr(apply.ShipName))
                    .Replace("{#Saillings}", GetStr(apply.Saillings))
                    .Replace("{#IO0}", apply.IO.ToString() == "0" ? "☑" : "□")
                    .Replace("{#StartPort}", GetStr(apply.StartPort))
                    .Replace("{#ArrivedTime}", GetStr(Convert.ToDateTime(apply.ArrivedTime).ToString("yyyy-MM-dd")))
                    .Replace("{#Nationality}", GetStr(apply.Nationality))
                    .Replace("{#Operator}", GetStr(apply.Operator))
                    .Replace("{#IO1}", apply.IO.ToString() == "1" ? "☑" : "□")
                    .Replace("{#WorkBerth}", GetStr(apply.WorkBerth))
                    .Replace("{#WorkTime}", GetStr(Convert.ToDateTime(apply.WorkTime).ToString("yyyy-MM-dd")))
                    .Replace("{#Declarer}", apply.Declarer.ToString() == "" ? GetStr(apply.Ship) : GetStr(apply.Declarer))
                    .Replace("{#DecCertificateNo}", GetStr(apply.DecCertificateNo))
                    .Replace("{#CreateTime}", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"))
                    .Replace("{#EmergencyName}", apply.EmergencyName + "、" + apply.EmergencyTel + "、" + apply.EmergencyFax + "、" + apply.RmergencyEmail);

                Model.BulkFreight bulk = new Model.BulkFreight();
                IList list = bulk.GetAllList(" and AppGuid='" + AppGuid + "'", "Id");
                foreach (var item in list)
                {
                    if (list.IndexOf(item) < 6)
                    {
                        bulkList +=
                            "<tr style='mso-yfti-irow:1;height:21.75pt'><td width=206 colspan=2 valign=top style='width:154.25pt;border-top:none;border-left:solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).BfGoodsName + "</o:p></span></p></td><td width=95 valign=top style='width:70.9pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).BfGoodsGroup + "</o:p></span></p></td><td width=92 valign=top style='width:69.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).Class + "</o:p></span></p></td><td width=97 colspan=2 valign=top style='width:72.75pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).DangerousNo + "</o:p></span></p></td><td width=123 valign=top style='width:92.1pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).BfTotalWeight + "</o:p></span></p></td><td width=109 valign=top style='width:81.9pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).DischargingPort + "</o:p></span></p></td><td width=126 colspan=2 valign=top style='width:94.5pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).Position + "</o:p></span></p></td><td width=154 valign=top style='width:115.2pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>" + ((CNVP.Model.BulkFreight)(item)).Remark + "</o:p></span></p></td></tr>";
                    }
                }
                for (int i = 0; i < 6-list.Count; i++)
                {
                    bulkList += "<tr style='mso-yfti-irow:1;height:21.75pt'><td width=206 colspan=2 valign=top style='width:154.25pt;border-top:none;border-left:solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=95 valign=top style='width:70.9pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=92 valign=top style='width:69.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=97 colspan=2 valign=top style='width:72.75pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=123 valign=top style='width:92.1pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=109 valign=top style='width:81.9pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=126 colspan=2 valign=top style='width:94.5pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td><td width=154 valign=top style='width:115.2pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;mso-border-top-alt:solid windowtext .5pt;mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext 1.5pt;padding:0cm 5.4pt 0cm 5.4pt;height:21.75pt'><p class=MsoNormal><span lang=EN-US style='font-size:9.0pt;mso-bidi-font-size:12.0pt'><o:p>&nbsp;</o:p></span></p></td></tr>";
                }
                content = content.Replace("{#BulkList}", bulkList);

                //审批意见

                if (accredit != null)
                {
                    //string xh = string.Empty;
                    //if (apply.PrintNum.Length == 1)
                    //{
                    //    xh = DateTime.Now.ToString("yyyyMMdd") + "0" + apply.PrintNum;
                    //}
                    //else
                    //{
                    //    xh = apply.PrintNum;
                    //}
                    content = content.Replace("{#spyj}", "准予备案");
                    content = content.Replace("{#spsj}", DateTime.Now.ToString("yyyy-MM-dd"));
                }
                Response.Write(content);
            }
            
        }

        private string GetStr(string TypeName)
        {
            string str = string.Empty;
            str = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + TypeName
                  + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            return str;
        }
    }
}