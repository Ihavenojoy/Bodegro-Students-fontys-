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
        public ProtocolDTO ObjectToDTO(Protocol protocol)
        {
            ProtocolDTO protocoldto = new ProtocolDTO {
                Name = protocol.Name,
                Description = protocol.Description,
                Admin_ID = protocol.Admin_ID
            };
            return protocoldto;
        }
    }
}
