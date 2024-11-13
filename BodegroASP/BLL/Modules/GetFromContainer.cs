using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Containers;
using Interfaces;
using Microsoft.Extensions.Configuration;

namespace Domain.Modules
{
    internal class GetFromContainer
    {
        StepContainer StepContainer;
        private readonly IConfiguration iConfiguration;
        public GetFromContainer()
        {
            StepDAL SDal = new(iConfiguration);
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
