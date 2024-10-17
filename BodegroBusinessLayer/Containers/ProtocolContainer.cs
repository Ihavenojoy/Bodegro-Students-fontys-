using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using BodegroInterfaces;
using DTO;
using BLL.DTOConverter;

namespace BLL.Containers
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
