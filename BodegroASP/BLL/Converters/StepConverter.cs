using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converter
{
    public class StepConverter
    {
        public Step DTOToObject(StepDTO stepDTO)
        {
            Step step = new Step(stepDTO.ID, stepDTO.ProtocolID, stepDTO.Name, stepDTO.Description, stepDTO.Order, stepDTO.Test, stepDTO.Interval);
            return step;
        }

        public List<Step> ListDTOToListObject(List<StepDTO> stepDTOs)
        {
            List<Step> list = new List<Step>();
            foreach (var stepDTO in stepDTOs)
            {
                Step step = new Step(stepDTO.ID, stepDTO.ProtocolID, stepDTO.Name, stepDTO.Description, stepDTO.Order, stepDTO.Test, stepDTO.Interval);
                list.Add(step);
            }
            return list;
        }
        public StepDTO ObjectToDTO(Step step)
        {
            StepDTO stepDTO = new StepDTO
            {
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
