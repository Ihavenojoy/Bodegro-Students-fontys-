using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Containers.StepFile;
using Domain.Modules;
using Domain.Converter;
using Interfaces;
using Microsoft.Extensions.Configuration;

namespace Domain.Services
{
    internal class GetFromContainer
    {
        StepContainer? StepContainer;
        //StepDAL? SDal;
        private readonly IStep SDal;
        public GetFromContainer(IStep sDal)
        {
            SDal = sDal;
            StepContainer = new(SDal);
        }
        public List<Protocol> AskStepsFormProtocols(List<Protocol> protocols)
        {
            foreach (Protocol protocol in protocols)
            {
                protocol.Steps = StepContainer!.GetStepsOfProtocol(protocol);
            }
            return protocols;
        }
        public Protocol AskStepsFormProtocol(Protocol protocol)
        {
            protocol.Steps = StepContainer!.GetStepsOfProtocol(protocol);
            return protocol;
        }
    }
}
