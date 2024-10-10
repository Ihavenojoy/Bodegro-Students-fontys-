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
        public int Admin_ID { get; set; }

        public Protocol(string Name, List<Step> Steps, string Description, int admin_ID)
        {
            this.Name = Name;
            this.Steps = Steps;
            this.Description = Description;
            Admin_ID = admin_ID;
        }
        public string ToString()
        {
            return Name;
        }
    }
}
