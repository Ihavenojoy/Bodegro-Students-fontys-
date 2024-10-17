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
        ProtocolDTOConverter protocolDTOConverter;
        public void AddProtocol(string Name, string Description, User user)
        {
            Protocol protocol = new Protocol(Name, Description, user.ID);
            //Dal.CreateProtocol(protocolDTOConverter.ObjectToDTO(protocol));
        }
    }
}
