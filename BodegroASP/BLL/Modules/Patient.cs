using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain.Modules
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string MedicalHistory { get; set; }

        public Patient(string Name, string Email, int PhoneNumber, string MedicalHistory)
        {
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
        }
        public Patient(int ID, string Name, string Email, int PhoneNumber, string MedicalHistory)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
        }
        public bool IDCheck(int checkID)
        {
            bool check = false;
            if (checkID == ID)
            {
                check = true;
            }
            return check;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
