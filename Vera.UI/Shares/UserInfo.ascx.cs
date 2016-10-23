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
    public partial class UserInfo : System.Web.UI.UserControl
    {
        public IUserRepository userRep { get; set; }
        public string UserInfoHtml = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultUser"]);
            var userInfo = userRep.GetUserInfoByUserId(userId);
            UserInfoHtml += "<div class=\"row bt-margin\">";
            UserInfoHtml += "<div class=\"l-detail-name\">姓名：</div>";
            UserInfoHtml += "<div class=\"l-detail-name\">" + userInfo.NickName + "</div>";
            UserInfoHtml += "</div>";
            UserInfoHtml += "<div class=\"row bt-margin\">";
            UserInfoHtml += "<div class=\"l-detail-name\">性别：</div>";
            UserInfoHtml += "<div class=\"l-detail-name\">" + userInfo.Gender + "</div>";
            UserInfoHtml += "</div>";
            UserInfoHtml += "<div class=\"row bt-margin\">";
            UserInfoHtml += "<div class=\"l-detail-name\">职业：</div>";
            UserInfoHtml += "<div class=\"l-detail-name\">" + userInfo.Profession + "</div>";
            UserInfoHtml += "</div>";
            UserInfoHtml += "<div class=\"row bt-margin\">";
            UserInfoHtml += "<div class=\"l-detail-name\">领域：</div>";
            UserInfoHtml += "<div class=\"l-detail-name\">" + userInfo.Major + "</div>";
            UserInfoHtml += "</div>";
        }
    }
}