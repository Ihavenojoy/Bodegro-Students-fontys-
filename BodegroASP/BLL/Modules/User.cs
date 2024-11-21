using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            this.Name = name;
            this.Email = email;
            this.Role = role;
            this.IsActive = isActive;
        }
        public User(int ID, string name, string email, Role role, bool isActive)
        {
            this.ID = ID;
            this.Name = name;
            this.Email = email;
            this.Role = role;
            this.IsActive = isActive;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
