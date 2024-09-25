﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    internal class Subscription
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Protocol Protocol { get; set; }
        public int StepsTaken { get; set; }

        public Subscription(DateTime StarDate, DateTime EndDate, Protocol Protocol) 
        { 
            this.StartDate = StarDate;
            this.EndDate = EndDate;
            this.Protocol = Protocol;
            StepsTaken = 0;
        }
    }
}