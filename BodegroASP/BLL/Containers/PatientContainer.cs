﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using BodegroInterfaces;
using DTO;

namespace Domain.Containers
{
    public class PatientContainer
    {
        private IPatient Dal = new PatientDAL();
        private SubscriptionContainer SubscriptionContainer;
        public List<Patient> AskAllPatientsOfDoctor(User user)
        {
            List<Patient> patients = new List<Patient>();
            //foreach loop met de database waar PatientDTO wordt opgehaald en wordt Convert waarna het in de list komt
            return patients;
        }

    }
}