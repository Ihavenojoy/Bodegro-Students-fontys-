﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record StepDTO
    {
        public int ID { get; }
        public int ProtocolID { get; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Order { get; set; }
        public string Test { get; set; }
        public int Interval { get; set; }
    }
}
