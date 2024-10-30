using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IProtocol
    {
        public int CreateProtocol(ProtocolDTO protocol);
        public List<ProtocolDTO> GetAllProtocols();
    }
}
