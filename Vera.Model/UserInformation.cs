using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vera.Model
{
    public class UserInformation
    {
        public int InfoId { get; set; }
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string Major { get; set; }
        public string Signature { get; set; }
    }
}
