using Vera.Interface.BLL;
using Vera.Interface.DAL;

namespace Vera.Business
{
    public class UserRepository : IUserRepository
    {
        private IUserDataAccess users;
        public UserRepository(IUserDataAccess _users)
        {
            users = _users;
        }

        public bool Login(string username, string password)
        {
            return users.Login(username, password);
        }

        public string ValidateLogin(string username, string password)
        {
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(username))
            {
                errMsg = "用户名不能为空";
            }
            else if (string.IsNullOrEmpty(password))
            {
                errMsg = "密码不能为空";
            }
            return errMsg;
        }
    }
}
