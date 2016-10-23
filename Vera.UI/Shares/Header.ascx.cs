using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.UI.Constant;

namespace Vera.UI.Shares
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string HeaderTophtml = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = string.Empty;
            if (Session[SessionContainer.Login] == null)
            {
                HeaderTophtml += "<div class=\"header-login\"><a href=\"Register.aspx\">注册</a></div>";
                HeaderTophtml += "<div class=\"header-login\"><a href=\"Login.aspx\">登录</a></div>";
            }
            else
            {
                username = Session["user"].ToString();
                HeaderTophtml += "<div class=\"header-login\">你好，" + username + "</div>";
                HeaderTophtml += "<div class=\"header-login\"><a href=\"../LogOut.aspx\">登出</a></div>";
            }
        }
    }
}