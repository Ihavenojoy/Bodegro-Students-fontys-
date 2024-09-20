using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    internal class Patient
    {
        static public int PatientID = 0;
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<string> MedicalHistory { get; set; }
        public Regio Regio { get; set; }

        public Patient(string Name, string Email,int PhoneNumber, List<string> MedicalHistory, Regio Regio)
        {
            PatientID = PatientID++;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            this.Regio = Regio;
        }
    }
}
