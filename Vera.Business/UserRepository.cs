using Vera.Interface.BLL;
using Vera.Interface.DAL;
using Vera.Model;

namespace Vera.Business
{
    public class UserRepository : IUserRepository
    {
        private IUserDataAccess users;
        public UserRepository(IUserDataAccess _users)
        {
            users = _users;
        }

        public bool Login(User user)
        {
            return users.Login(user);
        }

        public string ValidateLogin(User user)
        {
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(user.UserName))
            {
                errMsg = "用户名不能为空";
            }
            else if (string.IsNullOrEmpty(user.Password))
            {
                errMsg = "密码不能为空";
            }
            return errMsg;
        }

        public int GetUserIdByUserName(string userName)
        {
            return users.GetUserIdByUserName(userName);
        }

        public UserInformation GetUserInfoByUserId(int userId)
        {
            return users.GetUserInfoByUserId(userId);
        }
    }
}
