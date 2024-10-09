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
        public Regio Regio { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public int DoctorID { get; set; }

        public Patient(string Name, string Email, int PhoneNumber, List<string> MedicalHistory,List<Subscription>Subscriptions, Regio Regio, int doctorID)
        {
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            this.Regio = Regio;
            ID = 1;
            DoctorID = doctorID;
            this.Subscriptions = Subscriptions;
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
        public string ToString()
        {
            return Name;
        }
    }
}
