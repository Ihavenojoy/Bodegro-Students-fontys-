using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record SubscriptionDTO
    {
        public DateTime StartDate { get; set; }
        public int ProtocolID { get; set; }
        public int PatientID { get; set; }
        public int StepsTaken { get; set; }
    }
}
