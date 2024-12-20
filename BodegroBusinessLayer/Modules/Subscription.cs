﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Modules
{
    public class Subscription
    {
        public DateTime StartDate { get; set; }
        public Protocol Protocol { get; set; }
        public int StepsTaken { get; set; }

        public Subscription(DateTime StarDate, Protocol Protocol)
        {
            StartDate = StarDate;
            this.Protocol = Protocol;
            StepsTaken = 0;
        }
    }
}
