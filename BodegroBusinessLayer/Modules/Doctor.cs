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
        public int PhoneNumber { get; set; }
        public Regio Regio { get; set; }
        public List<Patient> Patients { get; set; }
        public int AdminId { get; set; }
        public bool IsActive { get; set; }

        public Doctor(int ID, string Name, string Email, Regio Regio , int AdminId, bool IsActive) : base (ID , Name, Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.Regio = Regio;
            this.Patients = new List<Patient>();
            this.AdminId = AdminId;
            this.IsActive = IsActive;
        }

    }
}
