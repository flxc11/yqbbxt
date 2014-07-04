using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.user
{
    using CNVP.UI;
    using CNVP.Framework.Utils;
    public partial class reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Action = Request.Params["Action"];
            switch (Action)
            {
                case "reg":
                    Reg();
                    break;
            }
        }

        private void Reg()
        {
            Model.User model = new Model.User();
            model.UpdateModel();
            UserPage userPage = new UserPage();
            if (userPage.IsUserExists(model.UserName))
            {
                MessageBox.ShowMessage("此账号已存在，请重新注册！", "reg.aspx");
            }
            else
            {
                model.UserPass = Encrypt.Md5(model.UserPass);
                model.CreateTime = DateTime.Now;
                model.Insert();
                MessageBox.ShowMessage("注册成功，请登录！", "login.aspx");
            }
        }
    }
}