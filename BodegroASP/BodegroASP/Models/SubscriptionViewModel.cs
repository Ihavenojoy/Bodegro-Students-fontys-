using Domain.Modules;

namespace BodegroASP.Models
{
    public class SubscriptionViewModel
    {
        public DateTime StartDate { get; set; }
        public ProtocolViewModel Protocol { get; set; }
        public PatientViewModel Patient { get; set; }
        public int StepsTaken { get; set; }
    }
}
