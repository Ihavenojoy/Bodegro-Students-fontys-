
using Domain.Modules;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converter
{
    public class ProtocolConverter
    {
        public StepConverter stepconverter = new StepConverter();
        public Protocol DTOToObject(ProtocolDTO protocolDTO)
        {
            Protocol protocol = new Protocol(protocolDTO.ID , protocolDTO.Name, protocolDTO.Description, stepconverter.ListDTOToListObject(protocolDTO.Steps), protocolDTO.User_ID);
            return protocol;
        }
        public List<Protocol> ListDTOToListObject(List<ProtocolDTO> protocolDTOList)
        {
            List<Protocol> protocolList = new List<Protocol>();
            foreach (var sub in protocolDTOList)
            {
                Protocol protocol = new Protocol(sub.ID, sub.Name, sub.Description, stepconverter.ListDTOToListObject(sub.Steps), sub.User_ID);
                protocolList.Add(protocol);
            }
            return protocolList;
        }
        public ProtocolDTO ObjectToDTO(Protocol protocol)
        {
            ProtocolDTO protocoldto = new ProtocolDTO
            {
                ID = protocol.ID,
                Name = protocol.Name,
                Description = protocol.Description,
                User_ID = protocol.User_ID
            };
            return protocoldto;
        }
    }
}
