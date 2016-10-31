using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vera.Model;

namespace Vera.Interface.BLL
{
    public interface IUserRepository
    {
        bool Login(User user);
        string ValidateLogin(User user);
        int GetUserIdByUserName(string userName);
        UserInformation GetUserInfoByUserId(int userId);
        User GetUserByUserId(int userId);
    }
}
