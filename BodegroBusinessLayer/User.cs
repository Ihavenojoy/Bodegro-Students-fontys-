using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User (string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
}
