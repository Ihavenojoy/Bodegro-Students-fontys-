using Domain.Modules;

namespace Domain.Containers.ProtocolFile
{
    public interface IProtocolContainer
    {
        bool AddProtocol(Protocol protocol);
        List<Protocol> GetProtocols();
    }
}