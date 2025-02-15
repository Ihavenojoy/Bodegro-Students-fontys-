﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record ProtocolDTO
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StepDTO> Steps { get; set; }
        public int User_ID { get; set; }

    }
}
