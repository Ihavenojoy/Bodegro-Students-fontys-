using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IStep
    {
        public int CreateStep(StepDTO protocol);
        public List<StepDTO> GetStepsOfProtocol(int protocolID);
    }
}
