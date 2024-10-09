using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using BodegroInterfaces;
using DTO;

namespace BLL.Containers
{
    public class ProtocolContainer
    {
        IProtocol Dal = new ProtocolDAL();
        StepContainer StepContainer;
        public Protocol DTOToObject(ProtocolDTO protocolDTO)
        {
            Protocol protocol = new Protocol(protocolDTO.Name, StepContainer.DTOToObject(protocolDTO.Steps));
            return protocol;
        }
        public ProtocolDTO ObjectToDTO(Protocol protocol)
        {
            ProtocolDTO protocoldto = new ProtocolDTO(protocol.Name, StepContainer.ObjectToDTO(protocol.Steps));
            return protocoldto;
        }
    }
}
