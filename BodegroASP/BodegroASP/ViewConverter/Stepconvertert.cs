using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.ViewConverter
{
    public class Stepconvertert
    {
        public List<StepViewModel> ListObjectToView(List<Step> steps)
        {
            List<StepViewModel> views = new List<StepViewModel>();
            foreach (Step step in steps)
            {
                StepViewModel temp = new StepViewModel()
                {
                    Description = step.Description,
                    Interval = step.Interval,
                    Name = step.Name,
                    Order = step.Order,
                    Test = step.Test
                };
                views.Add(temp);
            }
            return views;
        }
    }
}
