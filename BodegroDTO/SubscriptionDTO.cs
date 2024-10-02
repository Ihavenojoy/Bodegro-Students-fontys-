using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    public record SubscriptionDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProtocolDTO Protocol { get; set; }
        public int StepsTaken { get; set; }

        public SubscriptionDTO(DateTime StarDate, DateTime EndDate, ProtocolDTO Protocol) 
        { 
            this.StartDate = StarDate;
            this.EndDate = EndDate;
            this.Protocol = Protocol;
            StepsTaken = 0;
        }
    }
}
