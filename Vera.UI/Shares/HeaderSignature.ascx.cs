using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;

namespace Vera.UI.Shares
{
    public partial class HeaderSignature : System.Web.UI.UserControl
    {
        public string HeaderWrodhtml = "";
        public IUserRepository userRep { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultUser"]);
            HeaderWrodhtml = userRep.GetUserInfoByUserId(userId).Signature;
        }
    }
}