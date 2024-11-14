using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using Interfaces;
using DTO;
using System.Numerics;
using Domain.Converter;

namespace Domain.Containers.PatientFile
{
    public class PatientContainer : IPatientContainer
    {
        private IPatient Dal;
        private PatientConverter objectconverter = new();
        public PatientContainer(IPatient dal)
        {
            Dal = dal;
        }
        public List<Patient> GetPatientsOfUser(User User)
        {
            List<Patient> list = new List<Patient>();
            List<int> PatientIDs = Dal.GetPatientIDOfUser(User.ID);
            foreach (int i in PatientIDs)
            {
                Patient patient = objectconverter.DTOToObject(Dal.GetPatient(i, User.ID));
                list.Add(patient);
            }
            return list;
        }
    }
}
