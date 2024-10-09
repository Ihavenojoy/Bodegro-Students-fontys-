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
        public List<Patient> Patients { get; set; }
        public int Admin_ID { get; set; }
        public bool IsActive { get; set; }

        public Doctor(int ID, string Name, string Email, Regio Regio , int Admin_ID, bool IsActive) : base (ID , Name, Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.Regio = Regio;
            this.Patients = new List<Patient>();
            this.Admin_ID = Admin_ID;
            this.IsActive = IsActive;
        }

    }
}
