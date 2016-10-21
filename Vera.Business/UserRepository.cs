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
    }
}
