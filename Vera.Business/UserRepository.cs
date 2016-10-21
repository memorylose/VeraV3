using Vera.Interface.BLL;

namespace Vera.Business
{
    public class UserRepository : IUserRepository
    {
        private IUserRepository users;
        public UserRepository(IUserRepository _users)
        {
            users = _users;
        }

        public bool Login(string username, string password)
        {
            return users.Login(username, password);
        }
    }
}
