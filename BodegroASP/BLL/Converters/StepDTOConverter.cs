using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOConverter
{
    public class StepDTOConverter
    {
        public StepDTO ObjectToDTO(Step step)
        {
            StepDTO stepDTO = new StepDTO { 
                ID = step.ID,
                ProtocolID = step.ProtocolID,
                Name = step.Name,
                Description = step.Description,
                Order = step.Order,
                Test = step.Test,
                Interval = step.Interval
            };
            return stepDTO;
        }
    }
}
