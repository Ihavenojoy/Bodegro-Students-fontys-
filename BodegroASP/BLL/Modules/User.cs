using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Enums;

namespace Domain.Modules
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public User(string Name, string Email, Role Role)
        {
            this.Name = Name;
            this.Email = Email;
            this.Role = Role;
        }
        public User(int ID, string Name, string Email, Role Role)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.Role = Role;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
