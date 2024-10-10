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
        StepContainer StepContainer;
        ProtocolDTOConverter protocolDTOConverter;
        public void AddProtocol(string Name, string Description, List<Step> Steps, User user)
        {
            Protocol protocol = new Protocol(Name, Steps, Description, user.ID);
            Dal.CreateProtocol(protocolDTOConverter.ObjectToDTO(protocol));
        }
    }
}
