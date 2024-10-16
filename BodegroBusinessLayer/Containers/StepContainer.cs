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


namespace BLL.Containers
{
    public class StepContainer
    {
        IStep Dal = new StepDAL();
        StepConverter stepConverter = new StepConverter();
        public void AddStep(string name, string description, int interval, int order, string test)
        {
            StepDTO step = new StepDTO
            {
                Name = name,
                Discription = description,
                Order = order,
                Test = test,
                Interval = interval
            };
            Dal.CreateStep(step);
        }
        //public Step GetStep(StepDTO stepDTO)
        //{
        //    return stepConverter.DTOToObject(stepDTO);
        //}
    }
}
