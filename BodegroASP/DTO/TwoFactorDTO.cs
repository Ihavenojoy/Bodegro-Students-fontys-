using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record TwoFactorDTO
    {
        public int UserId { get; set; }
        public string OTP { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
