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
        public List<Step> Steps { get; set; }
        public int User_ID { get; set; }

        public Protocol(string Name, string Description, List<Step> Steps, int User_ID)
        {
            this.Name = Name;
            this.Description = Description;
            this.Steps = Steps;
            this.User_ID = User_ID;
        }
        public Protocol(int ID, string Name, string Description, List<Step> Steps, int User_ID): this(Name, Description, Steps, User_ID)
        {
            this.ID = ID;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
