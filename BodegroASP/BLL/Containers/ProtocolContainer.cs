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

namespace Domain.Containers
{
    public class ProtocolContainer
    {
        IProtocol Dal = new ProtocolDAL();
        ProtocolDTOConverter protocolDTOConverter = new ProtocolDTOConverter();
        public void AddProtocol(Protocol protocol)
        {
            Dal.CreateProtocol(protocolDTOConverter.ObjectToDTO(protocol));
        }
        //public Protocol GetProtocol()
        //{
        //    return Dal.AskProtocol();
        //}
    }
}
