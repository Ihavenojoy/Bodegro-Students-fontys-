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
using Domain.Converters;

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
        public List<Patient> GetPatientsOfDoctor(Doctor doctor)
        {
            List<Patient> list = new List<Patient>();
            List<int> PatientIDs = Dal.GetPatientIDOfDoctor(doctor.ID);
            foreach (int i in PatientIDs)
            {
                Patient patient = objectconverter.DTOToObject(Dal.GetPatient(i, doctor.ID));
                list.Add(patient);
            }
            return list;
        }
    }
}
