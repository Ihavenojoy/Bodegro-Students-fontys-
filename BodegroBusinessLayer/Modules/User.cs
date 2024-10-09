using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Modules
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public User Verification()
        {
            AdminDAL adminDAL = new AdminDAL();
            DoctorDAL doctorDAL = new DoctorDAL();
            return null;
        }
    }
    
}
