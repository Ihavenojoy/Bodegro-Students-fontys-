using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using Interfaces;
using DTO;
using Domain.DTOConverter;
using Domain.ObjectConverter;
using Domain.Services;

namespace Domain.Containers
{
    public class ProtocolContainer
    {
        IProtocol Dal; 
        GetFromContainer GetSteps = new GetFromContainer();
        ProtocolDTOConverter protocolDTOConverter = new ();
        ProtocolConverter ProtConverter = new();
        public ProtocolContainer(IProtocol dal) 
        { 
            Dal = dal;
        }
        public List<Protocol> GetProtocols()
        {
            List<Protocol> Protocols = GetSteps.AskStepsFormProtocol(ProtConverter.ListDTOToListObject(Dal.GetAllProtocols()));
            return Protocols;
        }
        public bool AddProtocol(Protocol protocol)
        {
            bool isdone = Dal.CreateProtocol(protocolDTOConverter.ObjectToDTO(protocol));
            return isdone;
        }
    }
}
