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
        public int ID { get;}
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string MedicalHistory { get; set; }
        public int User_ID { get; set; }

        public Patient(string Name, string Email, int PhoneNumber, string MedicalHistory, int User_ID)
        {
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            this.User_ID = User_ID;
        }
        public Patient(int ID, string Name, string Email, int PhoneNumber, string MedicalHistory, int User_ID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            this.User_ID = User_ID;
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
