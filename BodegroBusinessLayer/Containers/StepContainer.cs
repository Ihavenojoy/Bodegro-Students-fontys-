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
        
    }
}
