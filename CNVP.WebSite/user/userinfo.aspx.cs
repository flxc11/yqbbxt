using CNVP.UI;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using CNVP.Framework.Utils;

    public partial class userinfo : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.User user = Model.User.Instance.GetModelById(UserLoginInfo.UserLoginID);
                user.SetWebControls(this.Page);
            }
            string action = Request.Params["action"];
            if (action == "EditUser")
            {
                Model.User user = new Model.User();
                user.UpdateModel();
                user.Id = Convert.ToInt32(UserLoginInfo.UserLoginID);
                if (!string.IsNullOrEmpty(UserPass1.Text))
                {
                    user.UserPass = Encrypt.Md5(UserPass1.Text);
                }

                user.Update();
                MessageBox.ShowMessage("修改成功！", "userinfo.aspx");
            }
        }
    }
}