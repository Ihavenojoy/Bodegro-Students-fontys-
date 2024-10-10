using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Modules
{
    public class Protocol
    {
        public int ID { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Step> Steps { get; set; }


        public Protocol(string Name, List<Step> Steps, string Description)
        {
            this.Name = Name;
            this.Steps = Steps;
            this.Description = Description;
        }
        public string ToString()
        {
            return Name;
        }
    }
}
