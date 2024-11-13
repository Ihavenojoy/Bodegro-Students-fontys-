using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using Interfaces;
using DTO;
using Domain.ObjectConverter;
using Domain.Services;

namespace Domain.Containers.ProtocolFile
{
    public class ProtocolContainer : IProtocolContainer
    {
        IProtocol Dal;
        GetFromContainer GetSteps = new GetFromContainer();
        ProtocolConverter protocolConverter;
        public ProtocolContainer(IProtocol dal, ProtocolConverter protocolConverter)
        {
            Dal = dal;
            this.protocolConverter = protocolConverter;
        }
        public List<Protocol> GetProtocols()
        {
            List<Protocol> Protocols = GetSteps.AskStepsFormProtocol(protocolConverter.ListDTOToListObject(Dal.GetAllProtocols()));
            return Protocols;
        }
        public bool AddProtocol(Protocol protocol)
        {
            bool isdone = Dal.CreateProtocol(protocolConverter.ObjectToDTO(protocol));
            return isdone;
        }
    }
}
