using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using DTO;
using BodegroInterfaces;


namespace BLL.Containers
{
    public class StepContainer
    {
        IStep Dal = new StepDAL();
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
        public List<StepDTO> ObjectToDTO(List<Step> steps)
        {
            List<StepDTO> list = new List<StepDTO>();
            foreach (Step step in steps)
            {
                StepDTO stepDTO = new StepDTO();
                list.Add(stepDTO);
            }
            return list;
        }
    }
}
