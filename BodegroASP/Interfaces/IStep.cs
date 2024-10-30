using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroInterfaces
{
    public interface IStep
    {
        public int CreateStep(StepDTO protocol);
    }
}
