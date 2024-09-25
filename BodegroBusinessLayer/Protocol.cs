using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    internal class Protocol
    {
        public string Name { get; set; }

        public List<Step> Steps { get; set; }


        public Protocol(string Name, List<Step> Steps) 
        { 
            this.Name = Name;
            this.Steps = Steps;
        }
    }
}
