using Domain.Modules;

namespace BodegroASP.Models
{
    public class ConfirmProtocolLinkingViewModel
    {
        public int Patientid { get; set; }
        public int Protocolid { get; set; }
        public DateTime StartDate { get; set; }
    }
}
