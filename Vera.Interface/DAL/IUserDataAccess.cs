using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vera.Model;

namespace Vera.Interface.DAL
{
    public interface IUserDataAccess
    {
        bool Login(User userModel);
        int GetUserIdByUserName(string userName);
        UserInformation GetUserInfoByUserId(int userId);
    }
}
