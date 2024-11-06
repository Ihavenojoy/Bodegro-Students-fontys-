using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectConverter
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
    }
}
