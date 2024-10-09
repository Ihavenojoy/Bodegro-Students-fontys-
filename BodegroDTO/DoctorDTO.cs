using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record DoctorDTO : UserDTO
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNunber { get; set; }
        public List<string> MedicalHistory { get; set; }
        public bool IsActive { get; set; }
        public int Regio { get; set; }
        public int Admin_ID { get; set; }
        List<SubscriptionDTO> Subscriptions { get; set; }

        public DoctorDTO(int ID, string Name,int PhoneNumber, string Email,bool IsActive, int Regio, int Admin_ID, List<string> MedicalHistory, List<SubscriptionDTO>Subscriptions) : base (ID, Name, Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNunber = PhoneNunber;
            this.MedicalHistory = MedicalHistory;
            this.IsActive = IsActive;
            this.Regio = Regio;
            this.Admin_ID = Admin_ID;
            this.Subscriptions = Subscriptions;
        }
    }
}
