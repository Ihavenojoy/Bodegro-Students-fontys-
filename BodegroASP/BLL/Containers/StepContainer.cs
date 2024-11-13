using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using DTO;
using Interfaces;
using Domain.DTOConverter;
using Domain.ObjectConverter;
using System.Runtime.CompilerServices;

namespace Domain.Containers
{
    public class StepContainer
    {
        IStep Dal;
        StepDTOConverter stepDTOConverter = new StepDTOConverter();
        StepConverter stepConverter = new StepConverter();
        public StepContainer(IStep dal)
        {
            Dal = dal;
        }
        public bool AddStep(Step step)
        {
            StepDTO stepDTO = stepDTOConverter.ObjectToDTO(step);
            return Dal.CreateStep(stepDTO);
        }
        public List<Step> GetStepsOfProtocol(Protocol protocol)
        {
            return stepConverter.ListDTOToListObject(Dal.GetStepsOfProtocol(protocol.ID));
        }
    }
}
