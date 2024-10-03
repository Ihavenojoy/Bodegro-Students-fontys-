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
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<string> MedicalHistory { get; set; }
        public Regio Regio { get; set; }
        public List<Subscription> subscriptions = new List<Subscription>();
        public int Doctor_ID { get; set; }

        public Patient(string Name, string Email, int PhoneNumber, List<string> MedicalHistory, Regio Regio, int doctor_ID)
        {
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            this.Regio = Regio;
            this.Doctor_ID = doctor_ID;
        }
        public bool IDCheck(int ID)
        {
            bool check = false;
            if (ID == PatientID)
            {
                check = true;
            }
            return check;
        }
    }
}
