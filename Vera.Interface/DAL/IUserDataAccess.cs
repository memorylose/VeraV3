using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vera.Interface.DAL
{
    public interface IUserDataAccess
    {
        bool Login(string username, string password);
    }
}
