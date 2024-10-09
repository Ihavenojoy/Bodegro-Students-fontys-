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
        public bool IsActive { get; set; }
        public int Regio { get; set; }
        public int Admin_ID { get; set; }

        public DoctorDTO(int ID, string Name,string Email,bool IsActive, int Regio, int Admin_ID) : base (ID, Name, Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.PhoneNunber = PhoneNunber;
            this.IsActive = IsActive;
            this.Regio = Regio;
            this.Admin_ID = Admin_ID;
        }
    }
}
