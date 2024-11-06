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

namespace Domain.Containers
{
    public class StepContainer
    {
        IStep Dal;
        StepDTOConverter stepConverter = new StepDTOConverter();
        public StepContainer(IStep dal)
        {
            Dal = dal;
        }
        public void AddStep(Step step)
        {
            StepDTO stepDTO = stepConverter.ObjectToDTO(step);
            Dal.CreateStep(stepDTO);
        }
    }
}
