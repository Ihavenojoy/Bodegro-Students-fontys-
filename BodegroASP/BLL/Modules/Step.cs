using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain.Modules
{
    public class Step
    {
        public int ID { get; set; }
        public int ProtocolID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order {  get; set; }
        public string Test { get; set; }
        public int Interval { get; set; }
        public Step(int ID,int ProtocolID, string Name, string Description, int Order, string Test, int Interval): this(ProtocolID, Name, Description, Order, Test, Interval)
        {
            this.ID = ID;
        }
        public Step(int ProtocolID, string Name, string Description, int Order, string Test, int Interval)
        {
            this.ProtocolID = ProtocolID;
            this.Name = Name;
            this.Description = Description;
            this.Order = Order;
            this.Test = Test;
            this.Interval = Interval;
        }
    }
}
