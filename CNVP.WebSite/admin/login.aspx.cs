using CNVP.Config;
using CNVP.Framework.Define;
using CNVP.Framework.Helper;
using CNVP.Framework.Utils;
using CNVP.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.admin
{
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

            Model.Admin model = Model.Admin.Instance.GetModelById(ht);
            if (!string.IsNullOrEmpty(model.Id.ToString()))
            {
                SystemInfo info = new SystemInfo();
                info.LoginID = model.Id.ToString();
                info.LoginName = model.UserName;

                //创建登录状态
                CookieHelper.WriteCookie(UIConfig.CookieName, info, UIConfig.Expires);


                Response.Redirect("Welcome.aspx");
            }
            else
            {
                MessageBox.ShowMessage("登录帐号或者密码不正确", "login.aspx");
            }
        }

        private void LoginOut()
        {
            CookieHelper.WriteCookie(UIConfig.CookieName, "", -1);
            Session.Clear();
            Session.Abandon();
        }
    }
}