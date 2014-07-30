using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    public partial class Notice : System.Web.UI.Page
    {
        public string AppGuid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppGuid = "http://cszhrmghgwz.vhost1.cnvp.com.cn/user/phone.aspx?AppGuid=" + Request.Params["AppGuid"];
            }
        }
    }
}