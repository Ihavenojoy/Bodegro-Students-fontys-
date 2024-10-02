using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    public record DoctorDTO : UserDTO
    {
        public int Regio { get; set; }

        public DoctorDTO(string username, string password, string email, int regio) : base (username, password, email)
        {
            this.Regio = regio;
        }
    }
}
