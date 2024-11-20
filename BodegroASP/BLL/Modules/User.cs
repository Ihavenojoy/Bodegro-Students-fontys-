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
        public bool IsActive { get; set; }

        public User(string name, string email, Role role, bool isActive)
        {
            this.Name = Name;
            this.Email = Email;
            this.Role = Role;
            this.IsActive = isActive;
        }
        public User(int ID, string name, string email, Role role):this(name, email, role, true)
        {
            this.ID = ID;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
