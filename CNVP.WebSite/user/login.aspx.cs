using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using System.Collections;

    using CNVP.Config;
    using CNVP.Framework.Cache;
    using CNVP.Framework.Define;
    using CNVP.Framework.Helper;
    using CNVP.Framework.Utils;
    using CNVP.UI;

    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Action = Request.Params["Action"];
                switch (Action)
                {
                    case "Login":
                        CheckLogin();
                        break;
                    case "LoginOut":
                        LoginOut();
                        break;
                    default:
                        LoginOut();
                        break;
                }
            }
        }

        private void CheckLogin()
        {
            string userName = Request.Params["UserName"];
            string userPass = Public.FilterSql(Request.Params["password"]);
            Hashtable ht = new Hashtable();
            ht.Add("UserName", userName);
            ht.Add("UserPass", Encrypt.Md5(userPass));

            Model.User model = Model.User.Instance.GetModelById(ht);
            if (!string.IsNullOrEmpty(model.Id.ToString()))
            {
                UserInfo info = new UserInfo();
                info.UserLoginID = model.Id.ToString();
                info.UserLoginName = model.UserName;

                //创建登录状态
                CookieHelper.WriteCookie(UIConfig.UserCookieName, info, UIConfig.Expires);


                Response.Redirect("Welcome.aspx");
            }
            else
            {
                MessageBox.ShowMessage("登录帐号或者密码不正确", "login.aspx");
            }
        }

        private void LoginOut()
        {
            CookieHelper.WriteCookie(UIConfig.UserCookieName, "", -1);
            Session.Clear();
            Session.Abandon();
        }
    }
}