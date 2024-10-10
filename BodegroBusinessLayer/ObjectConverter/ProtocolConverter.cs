using BLL.Containers;
using BLL.DTOConverter;
using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectConverter
{
    public class ProtocolConverter
    {
        StepConverter stepConverter;
        public Protocol DTOToObject(ProtocolDTO protocolDTO)
        {
            Protocol protocol = new Protocol(protocolDTO.Name, stepConverter.DTOToObject(protocolDTO.Steps), protocolDTO.Description);
            return protocol;
        }
    }
}
