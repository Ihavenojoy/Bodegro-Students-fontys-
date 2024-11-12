using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Containers;
using Interfaces;

namespace Domain.Modules
{
    internal class GetFromContainer
    {
        StepContainer StepContainer;
        public GetFromContainer()
        {
            StepDAL SDal = new();
            StepContainer = new(SDal);
        }
        public List<Protocol> AskStepsFormProtocol(List<Protocol> protocols)
        {
            foreach (Protocol protocol in protocols)
            {
                protocol.Steps = StepContainer.GetStepsOfProtocol(protocol);
            }
            return protocols;
        }
    }
}
