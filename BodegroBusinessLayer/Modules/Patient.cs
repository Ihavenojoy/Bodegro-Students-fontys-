using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enums;
using DAL;

namespace BLL.Modules
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<string> MedicalHistory { get; set; }
        public int Doctor_ID { get; set; }

        public Patient(string Name, string Email, int PhoneNumber, List<string> MedicalHistory, int doctor_ID)
        {
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            Doctor_ID = doctor_ID;
        }
        public Patient(int ID, string Name, string Email, int PhoneNumber, List<string> MedicalHistory, int doctor_ID):this(Name, Email, PhoneNumber, MedicalHistory, doctor_ID)
        {
            this.ID = ID;
            ID = 1;
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
