﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using DTO;
using Interfaces;
using Domain.Converter;
using System.Runtime.CompilerServices;

namespace Domain.Containers.StepFile
{
    public class StepContainer : IStepContainer
    {
        IStep Dal;
        StepConverter stepConverter = new();
        public StepContainer(IStep dal)
        {
            Dal = dal;
        }
        public bool AddStep(Step step)
        {
            StepDTO stepDTO = stepConverter.ObjectToDTO(step);
            return Dal.CreateStep(stepDTO);
        }
        public List<Step> GetStepsOfProtocol(Protocol protocol)
        {
            return stepConverter.ListDTOToListObject(Dal.GetStepsOfProtocol(protocol.ID));
        }
        public List<Step> GetStepsOfProtocol(int protocolid)
        {
            return stepConverter.ListDTOToListObject(Dal.GetStepsOfProtocol(protocolid));
        }
    }
}
