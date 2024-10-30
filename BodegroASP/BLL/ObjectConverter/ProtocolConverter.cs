using BLL.DTOConverter;
using BLL.Modules;
using DAL;
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
        public Protocol DTOToObject(ProtocolDTO protocolDTO)
        {
            Protocol protocol = new Protocol(protocolDTO.Name, protocolDTO.Description, protocolDTO.Admin_ID);
            return protocol;
        }
        public List<Protocol> DTOToObjectList(List<ProtocolDTO> protocolDTOList)
        {
            List<Protocol> protocolList = new List<Protocol>();
            foreach (var sub in protocolDTOList)
            {
                Protocol protocol = new Protocol(sub.Name, sub.Description, sub.Admin_ID);
                protocolList.Add(protocol);
            }
            return protocolList;
        }
    }
}
