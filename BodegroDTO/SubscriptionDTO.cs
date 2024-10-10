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
        public ProtocolDTO Protocol { get; set; }
        public int StepsTaken { get; set; }

        public SubscriptionDTO(DateTime StarDate, ProtocolDTO Protocol) 
        { 
            this.StartDate = StarDate;
            this.Protocol = Protocol;
            StepsTaken = 0;
        }
    }
}
