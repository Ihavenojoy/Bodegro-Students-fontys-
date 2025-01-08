using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules
{
    public class TwoFactor
    {
        public int UserId { get; set; }
        public string OTP {  get; set; }
        public DateTime RequestTime { get; set; }
        public TwoFactor(int userId, string oTP, DateTime requestTime)
        {
            UserId = userId;
            OTP = oTP;
            RequestTime = requestTime;
        }
    }
}
