﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record StepDTO
    {
        public int Time {  get; set; }
        public string Discription { get; set; }
    }
}