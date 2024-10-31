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
            Step step = new Step(stepDTO.ID, stepDTO.ProtocolID, stepDTO.Name, stepDTO.Discription, stepDTO.Order, stepDTO.Test, stepDTO.Interval);
            return step;
        }
    }
}
