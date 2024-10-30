﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record PatientDTO
    {
        public int ID { get;}
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<string> MedicalHistory { get; set; }
        public int Doctor_ID { get; set; }
    }
}