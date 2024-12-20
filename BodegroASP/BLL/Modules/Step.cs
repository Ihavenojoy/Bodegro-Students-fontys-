﻿using System;
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
        public string Discription { get; set; }
        public int Order {  get; set; }
        public string Test { get; set; }
        public int Interval { get; set; }
        public Step(int ID,int ProtocolID, string Name, string Discription, int Order, string Test, int Interval)
        {
            this.ID = ID;
            this.ProtocolID = ProtocolID;
            this.Name = Name;
            this.Discription = Discription;
            this.Order = Order;
            this.Test = Test;
            this.Interval = Interval;
        }
        public Step(int ProtocolID, string Name, string Discription, int Order, string Test, int Interval)
        {
            this.ProtocolID = ProtocolID;
            this.Name = Name;
            this.Discription = Discription;
            this.Order = Order;
            this.Test = Test;
            this.Interval = Interval;
        }
    }
}
