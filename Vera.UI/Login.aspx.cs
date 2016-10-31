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
            Vera.Model.User user = new Model.User() { UserName = txtUsername.Value, Password = txtPassword.Value };
            string validationErrors = this.userRep.ValidateLogin(user);

            if (string.Equals(validationErrors, string.Empty))
            {
                if (this.userRep.Login(user))
                {
                    int userId = this.userRep.GetUserIdByUserName(user.UserName);
                    Session[SessionContainer.Login] = userId.ToString();
                    Response.Redirect("/home");
                }
                else
                {
                    validationErrors = "用户名密码错误";
                    txtUsername.Value = string.Empty;
                    txtPassword.Value = string.Empty;
                }
            }
            LoginErrorMessageshtml = validationErrors;
        }
    }
}