using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace Domain.Modules
{
    public class Admin : User
    {
        public Admin(string Name, string Email) : base(Name, Email)
        {
            this.Name = Name;
            this.Email = Email;
        }

        public Admin(int ID ,string Name, string Email) : base(ID, Name, Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
        }
    }

}
