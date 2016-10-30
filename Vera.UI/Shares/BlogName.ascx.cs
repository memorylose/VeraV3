using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vera.UI.Shares
{
    public partial class BlogName : System.Web.UI.UserControl
    {
        public string BlogNameHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            BlogNameHtml += "<a href=\"/Home\"><img src=\"/images/logo.png\" class=\"header-img \"/></a>";
        }
    }
}