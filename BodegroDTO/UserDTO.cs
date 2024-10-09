﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public abstract record UserDTO
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
