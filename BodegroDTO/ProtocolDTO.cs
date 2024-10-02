using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    public record ProtocolDTO
    {
        public string Name { get; set; }

        public List<StepDTO> Steps { get; set; }


        public ProtocolDTO(string Name, List<StepDTO> Steps) 
        { 
            this.Name = Name;
            this.Steps = Steps;
        }
    }
}
