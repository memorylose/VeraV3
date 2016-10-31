using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;
using Vera.UI.Constant;

namespace Vera.UI.Shares
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string HeaderTophtml = "";
        public IUserRepository userRep { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionContainer.Login] == null)
            {
                //HeaderTophtml += "<div class=\"header-login\"><a href=\"Register.aspx\">注册</a></div>";
                HeaderTophtml += "<div class=\"header-login\"><a href=\"/login\">登录</a></div>";
            }
            else
            {
                var users = userRep.GetUserByUserId(Convert.ToInt32(Session[SessionContainer.Login]));
                HeaderTophtml += "<div class=\"header-login\"><a href=\"../LogOut.aspx\">登出</a></div>";
                HeaderTophtml += "<div class=\"header-login\">你好，" + users.UserName + "</div>";  
            }
        }
    }
}