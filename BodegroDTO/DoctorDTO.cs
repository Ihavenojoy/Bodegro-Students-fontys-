using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record DoctorDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Regio { get; set; }
        public int Admin_ID { get; set; }
        public int Regio { get; set; }
        public int Admin_ID { get; }

        public DoctorDTO(string username, string email, int regio, int admin_ID) : base (username, email)
        {
            this.Regio = regio;
            this.Admin_ID = admin_ID;
        }
    }
}
