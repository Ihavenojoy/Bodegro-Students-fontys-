using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using Interfaces;
using DTO;
using Domain.ObjectConverter;

namespace Domain.Containers
{
    public class PatientContainer
    {
        private IPatient Dal;
        PatientConverter Converter = new();
        public PatientContainer(IPatient dal) 
        {
            Dal = dal;
        }
        public List<Patient> AskAllPatientsOfDoctor(User user)
        {
            List<Patient> patients = new List<Patient>();
            //foreach loop met de database waar PatientDTO wordt opgehaald en wordt Convert waarna het in de list komt
            return patients;
        }
        public List<Patient> GetPatients(Doctor doctor)
        {
            List<Patient> list = new List<Patient>();
            List<int> PatientIDs = Dal.GetPatientIDOfDoctor(doctor.ID);
            for (int i = 0; i < PatientIDs.Count; i++)
            {
                list.Add(Converter.DTOToObject(Dal.GetPatient(PatientIDs[i], doctor.ID)));
            }
            return list;
        }

    }
}
