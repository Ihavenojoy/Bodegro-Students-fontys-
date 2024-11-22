using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using Interfaces;
using DTO;
using Domain.Converter;
using Domain.Services;

namespace Domain.Containers.ProtocolFile
{
    public class ProtocolContainer : IProtocolContainer
    {
        IProtocol Dal;
        GetFromContainer GetSteps;
        ProtocolConverter protocolConverter = new();
        public ProtocolContainer(IProtocol pdal,IStep Sdal)
        {
            Dal = pdal;
            GetSteps = new(Sdal);
        }
        public List<Protocol> GetProtocols()
        {
            List<Protocol> Protocols = GetSteps.AskStepsFormProtocol(protocolConverter.ListDTOToListObject(Dal.GetAllProtocols()));
            return Protocols;
        }
        public bool AddProtocol(Protocol protocol)
        {
            bool isdone = Dal.CreateProtocol(protocolConverter.ObjectToDTO(protocol));
            return isdone;
        }
        public Protocol GetProtocol(string name)
        {
            return protocolConverter.DTOToObject(Dal.GetProtocol(name));
        }
        public Protocol GetProtocolbyid(int id)
        {
            return protocolConverter.DTOToObject(Dal.GetProtocolbyid(id));
        }
    }
}
