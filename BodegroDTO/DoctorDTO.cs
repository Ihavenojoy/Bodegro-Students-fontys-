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
        public bool IsActive { get; set; }
        public int Regio { get; set; }
        public int Admin_ID { get; set; }
    }
}
