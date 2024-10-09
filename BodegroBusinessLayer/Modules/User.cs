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
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int ID, string Name, string Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
        }
        public User Verification()
        {
            AdminDAL adminDAL = new AdminDAL();
            DoctorDAL doctorDAL = new DoctorDAL();
            return null;
        }
    }
    
}
