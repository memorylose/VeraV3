using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;

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
            if (this.userRep.Login(txtUsername.Value, txtPassword.Value))
            {
                //success
            }
            else
            {
                //failed
            }
        }
    }
}