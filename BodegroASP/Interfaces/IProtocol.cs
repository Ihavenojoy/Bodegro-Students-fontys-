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
        public bool CreateProtocol(ProtocolDTO protocol);
        public List<ProtocolDTO> GetAllProtocols();
        public ProtocolDTO GetProtocol(string name);
    }
}
