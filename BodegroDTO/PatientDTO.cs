﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record PatientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<string> MedicalHistory { get; set; }
        public int Regio { get; set; }
        public List<SubscriptionDTO> subscriptions = new List<SubscriptionDTO>();

        public PatientDTO(string Name, string Email,int PhoneNumber, List<string> MedicalHistory, int Regio)
        {
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.MedicalHistory = MedicalHistory;
            this.Regio = Regio;
        }
    }
}