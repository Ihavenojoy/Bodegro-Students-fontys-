using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain.Modules
{
    public class Protocol
    {
        public int ID { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        List<Step> Steps { get; set; }
        public int Admin_ID { get; set; }

        public Protocol(string Name, string Description, List<Step> Steps, int Admin_ID)
        {
            this.Name = Name;
            this.Description = Description;
            this.Steps = Steps;
            this.Admin_ID = Admin_ID;
        }
        public Protocol(int ID, string Name, string Description, List<Step> Steps, int Admin_ID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Steps = Steps;
            this.Admin_ID = Admin_ID;
        }
        public string ToString()
        {
            return Name;
        }
    }
}
