using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Modules
{
    public class Admin : User
    {
        public Admin(string username, string password, string email) : base(username, password, email)
        {

        }
    }

}
