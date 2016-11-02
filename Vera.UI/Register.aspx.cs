using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vera.Interface.BLL;
using Vera.Model;

namespace Vera.UI
{
    public partial class Register : System.Web.UI.Page
    {
        public IUserRepository userRep { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            User userModel = new Model.User();
            userModel.UserName = txtUsername.Value;
            userModel.Password = txtPassword.Value;
            userModel.Email = txtMail.Value;
            userModel.CreateDate = DateTime.Now;
            userModel.UpdateDate = DateTime.Now;
            int userId = userRep.CreateUser(userModel);
            if (userId > 0)
            {
                UserInformation userInfoModel = new UserInformation();
                userInfoModel.UserId = userId;
                userInfoModel.Gender = txtGender.Value;
                userInfoModel.Major = txtMajor.Value;
                userInfoModel.NickName = txtNickname.Value;
                userInfoModel.Profession = txtPro.Value;
                userInfoModel.Signature = txtSig.Value;
                if (userRep.CreateUserInformation(userInfoModel))
                {
                    Response.Redirect("/login");
                }
            }
        }
    }
}