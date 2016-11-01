using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vera.UI.Constant;

namespace Vera.UI.Base
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load);
        }

        void BasePage_Load(object sender, EventArgs e)
        {
            if (Session[SessionContainer.Login] == null)
            {
                Response.Redirect("/Login");
            }
        }
    }
}