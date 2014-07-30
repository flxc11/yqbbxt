using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using System.Collections;

    public partial class phone : System.Web.UI.Page
    {
        public string IO, ShipName, Saillings, Operator, StartPort, ArrivedTime, WorkBerth, AppState = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string appGuid = Request.Params["AppGuid"];
                if (!string.IsNullOrEmpty(appGuid))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Guid", appGuid);
                    Model.Application appli = Model.Application.Instance.GetModelById(ht);
                    IO = appli.IO.ToString() == "1" ? "出港" : "进港";
                    ShipName = appli.ShipName;
                    Saillings = appli.Saillings;
                    Operator = appli.Operator;
                    StartPort = appli.StartPort;
                    ArrivedTime = Convert.ToDateTime(appli.ArrivedTime).ToString("yyyy-MM-dd");
                    WorkBerth = appli.WorkBerth;
                    AppState = GetState(appli.AppState.ToString());
                }
            }
        }

        private string GetState(string state)
        {
            string str = string.Empty;
            if (state == "0")
            {
                str = "待审批";
            }
            else if (state == "1")
            {
                str = "已审批";
            }
            else if (state == "2")
            {
                str = "材料补正";
            }
            else if (state == "3")
            {
                str = "不予备案";
            };
            return str;
        }
    }
}