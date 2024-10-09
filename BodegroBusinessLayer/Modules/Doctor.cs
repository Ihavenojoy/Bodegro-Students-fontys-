using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enums;
using DAL;

namespace BLL.Modules
{
    public class Doctor
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Regio Regio { get; set; }
        public int Admin_ID { get; }

        public Doctor(string name, string email, bool isActive, Regio regio, int admin_ID)
        {
            Name = name;
            Email = email;
            IsActive = isActive;
            Regio = regio;
            Admin_ID = admin_ID;
        }
        public Doctor(int id, string name, string email, bool isActive, Regio regio, int admin_ID) : this(name, email, isActive, regio, admin_ID)
        {
            ID = id;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
