using CNVP.Framework.Utils;
using CNVP.UI;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite.admin
{
    public partial class ManagerAdd : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.Admin admin = new Model.Admin();
            admin.UpdateModel();
            CNVP.UI.AdminPage adminpage = new AdminPage();
            if (adminpage.IsUserExists(admin.UserName))
            {
                MessageBox.ShowMessage("此用户名已存在", "ManagerAdd.aspx");
            }
            else
            {
                admin.UserPass = Encrypt.Md5(admin.UserPass);
                admin.CreateTime = DateTime.Now;
                admin.Insert();
                MessageBox.ShowMessage("用户添加成功", "ManagerList.aspx");
            }
        }
    }
}