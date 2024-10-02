using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodegroBusinessLayer.Enums;

namespace BodegroBusinessLayer.Modules
{
    public class Doctor : User
    {
        public Regio Regio { get; set; }

        public Doctor(string username, string password, string email, Regio regio) : base(username, password, email)
        {
            Regio = regio;
        }
    }
}
