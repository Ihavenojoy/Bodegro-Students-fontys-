﻿namespace BodegroASP.Models
{
    public class StepViewModel
    {
        public int ID { get; set; }
        public int ProtocolID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Test { get; set; }
        public int Interval { get; set; }
    }
}
