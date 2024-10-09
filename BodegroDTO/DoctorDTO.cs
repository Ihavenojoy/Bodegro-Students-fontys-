using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record DoctorDTO : UserDTO
    {
        public int Regio { get; set; }
        public int Admin_ID { get; }

        public DoctorDTO(string username, string password, string email, int regio, int admin_ID) : base (username, password, email)
        {
            this.Regio = regio;
            this.Admin_ID = admin_ID;
        }
    }
}
