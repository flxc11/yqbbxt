using CNVP.UI;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    public partial class userinfo : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.User user = Model.User.Instance.GetModelById(UserLoginInfo.UserLoginID);
                user.SetWebControls(this.Page);
            }
        }
    }
}