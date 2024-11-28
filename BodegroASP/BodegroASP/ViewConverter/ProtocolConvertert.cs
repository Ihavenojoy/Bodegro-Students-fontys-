using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.ViewConverter
{
    public class ProtocolConvertert
    {
        public Stepconvertert converter = new Stepconvertert();
        public List<ProtocolViewModel> ListObjectToView(List<Protocol> protocols)
        {
            List<ProtocolViewModel> vieuws = new List<ProtocolViewModel>();
            foreach (Protocol protocol in protocols)
            {
                ProtocolViewModel viewModel = new ProtocolViewModel()
                {
                    ID = protocol.ID,
                    Description = protocol.Description,
                    Name = protocol.Name,
                    Steps = converter.ListObjectToView(protocol.Steps),
                    User_ID = protocol.User_ID
                };
                vieuws.Add(viewModel);
            }
            return vieuws;
        }
        public ProtocolViewModel ObjectToView(Protocol protocol)
        {

                ProtocolViewModel viewModel = new ProtocolViewModel()
                {
                    ID = protocol.ID,
                    Description = protocol.Description,
                    Name = protocol.Name,
                    Steps = converter.ListObjectToView(protocol.Steps),
                    User_ID = protocol.User_ID
                };
            return viewModel;
        }
    }
}
