﻿using System;
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
using System.Security.Authentication;

namespace Domain.Containers.ProtocolFile
{
    public class ProtocolContainer : IProtocolContainer
    {
        IProtocol Dal;
        GetFromStepContainer GetSteps;
        ProtocolConverter protocolConverter = new();
        public ProtocolContainer(IProtocol pdal,IStep Sdal)
        {
            Dal = pdal;
            GetSteps = new(Sdal);
        }
        public List<Protocol> GetProtocols()
        {
            List<Protocol> Protocols = GetSteps.AskStepsFormProtocols(protocolConverter.ListDTOToListObject(Dal.GetAllProtocols()));
            return Protocols;
        }
        public bool AddProtocol(Protocol protocol)
        {
            bool isdone = Dal.CreateProtocol(protocolConverter.ObjectToDTO(protocol));
            return isdone;
        }
        public Protocol GetProtocol(string name)
        {
            return GetSteps.AskStepsFormProtocol(protocolConverter.DTOToObject(Dal.GetProtocol(name)));
        }
        public Protocol GetProtocolbyid(int id)
        {
            return GetSteps.AskStepsFormProtocol(protocolConverter.DTOToObject(Dal.GetProtocolbyid(id)));
        }
        public List<Protocol> GetInactiveProtocols()
        {
            List<Protocol> result = GetSteps.AskStepsFormProtocols(protocolConverter.ListDTOToListObject(Dal.GetInactive()));
            return result;
        }
        public bool SetActive(int id)
        {
            return Dal.SetActive(id);
        }
    }
}
