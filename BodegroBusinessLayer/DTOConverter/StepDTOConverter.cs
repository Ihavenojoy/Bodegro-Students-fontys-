using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class StepDTOConverter
    {
        public List<StepDTO> ObjectToDTO(List<Step> steps)
        {
            List<StepDTO> list = new List<StepDTO>();
            foreach (Step step in steps)
            {
                StepDTO stepDTO = new StepDTO { 
                    Name = step.Name,
                    Discription = step.Discription,
                    Order = step.Order,
                    Test = step.Test,
                    Interval = step.Interval
                };
                list.Add(stepDTO);
            }
            return list;
        }
    }
}
