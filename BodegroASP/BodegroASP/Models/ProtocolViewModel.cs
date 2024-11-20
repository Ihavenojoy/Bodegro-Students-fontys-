using Domain.Modules;

namespace BodegroASP.Models
{
    public class ProtocolViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StepViewModel> Steps { get; set; }
        public int User_ID { get; set; }
    }
}
