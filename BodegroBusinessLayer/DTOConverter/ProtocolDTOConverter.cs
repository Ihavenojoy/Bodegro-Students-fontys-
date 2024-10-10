using BLL.Containers;
using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class ProtocolDTOConverter
    {
        StepDTOConverter stepDTOConverter;
        public ProtocolDTO ObjectToDTO(Protocol protocol)
        {
            ProtocolDTO protocoldto = new ProtocolDTO {
                Name = protocol.Name,
                Steps = stepDTOConverter.ObjectToDTO(protocol.Steps),
                Description = protocol.Description
            };
            return protocoldto;
        }
    }
}
