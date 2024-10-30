using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using DTO;
using BodegroInterfaces;
using BLL.DTOConverter;
using BLL.ObjectConverter;


namespace Domain.Containers
{
    public class StepContainer
    {
        IStep Dal = new StepDAL();
        StepDTOConverter stepConverter = new StepDTOConverter();
        public void AddStep(Step step)
        {
            StepDTO stepDTO = stepConverter.ObjectToDTO(step);
            Dal.CreateStep(stepDTO);
        }
    }
}
