using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CNVP.WebSite
{
    using CNVP.Framework.Utils;
    using CNVP.UI;

    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.AddHeader("pragma", "no-cache");
            Response.AddHeader("cache-control", "");
            Response.CacheControl = "no-cache";
            Response.ContentType = "application/json";
            string Action = Request.Params["Action"];
            switch (Action)
            {
                case "IsUserExists":  //判断用户是否存在
                    IsUserExists();
                    break;
            }
        }

        #region 判断用户是否存在

        private void IsUserExists()
        {
            string userName = Public.FilterSql(Request.Params["UserName"]);
            if (!string.IsNullOrEmpty(userName))
            {
                UserPage userPage = new UserPage();
                Response.Write(userPage.IsUserExists(userName));
                Response.End();
            }
            else
            {
                Response.Write("false");
                Response.End();
            }
            
        }
        #endregion
    }
}