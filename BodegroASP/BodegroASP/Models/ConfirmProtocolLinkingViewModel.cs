using Domain.Modules;

namespace BodegroASP.Models
{
    public class ConfirmProtocolLinkingViewModel
    {
        public int Patient { get; set; }
        public int Protocol { get; set; }
        public DateTime StartDate { get; set; }
    }
}
