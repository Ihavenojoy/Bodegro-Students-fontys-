using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enums;
using DAL;

namespace BLL.Modules
{
    public class Doctor : User
    {
        public Regio Regio { get; set; }
        public int Admin_ID { get; }

        public Doctor(string username, string password, string email, Regio regio, int admin_ID) : base(username, password, email)
        {
            Regio = regio;
            Admin_ID = admin_ID;
        }
    }
}
