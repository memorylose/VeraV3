using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;
using Vera.UI.Constant;

namespace Vera.UI
{
    public partial class Login : System.Web.UI.Page
    {
        public string LoginErrorMessageshtml = "";
        public IUserRepository userRep { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Value;
            string password = txtPassword.Value;
            string validationErrors = this.userRep.ValidateLogin(username, password);

            if (string.Equals(validationErrors, string.Empty))
            {
                if (this.userRep.Login(username, password))
                {
                    Session[SessionContainer.Login] = "";
                }
                else
                {
                    validationErrors = "用户名密码错误";
                    username = string.Empty;
                    password = string.Empty;
                }
            }
        }
    }
}