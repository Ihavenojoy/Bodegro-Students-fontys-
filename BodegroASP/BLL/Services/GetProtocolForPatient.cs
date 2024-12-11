using Domain.Converter;
using Domain.Modules;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetProtocolForPatient
    {
        IProtocol Dal;
        GetFromStepContainer GetSteps;
        ProtocolConverter protocolConverter = new();
        public GetProtocolForPatient(IProtocol pdal, IStep Sdal)
        {
            Dal = pdal;
            GetSteps = new(Sdal);
        }
        public List<Protocol> GetProtocolForSubscriptions(List<Subscription> subscriptions)
        {
            List<Protocol> returnlist = GetSteps.AskStepsFormProtocols(protocolConverter.ListDTOToListObject(Dal.GetAllProtocols()));
            List<Protocol> subProtocols = [];
            foreach (Subscription sub2 in subscriptions)
            {
                subProtocols.Add(sub2.Protocol);
            }
            for (int i = 0; i < returnlist.Count; i++)
            {
                foreach (Protocol protocol in subProtocols)
                {
                    if (protocol.Name == returnlist[i].Name)
                    {
                        returnlist.Remove(returnlist[i]);
                        i--;
                        break;
                    }
                }
            }
            return returnlist;
        }
    }
}
