using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectConverter
{
    public class StepConverter
    {
        public List<Step> DTOToObject(List<StepDTO> stepsDTO)
        {
            List<Step> list = new List<Step>();
            foreach (StepDTO stepDTO in stepsDTO)
            {
                Step step = new Step();
                list.Add(step);
            }
            return list;
        }
    }
}
