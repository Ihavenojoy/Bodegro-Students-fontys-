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
using Domain.ObjectConverter;

namespace Domain.Containers
{
    public class PatientContainer
    {
        private IPatient Dal;
        private PatientConverter objectconverter = new();
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
        

        public List<Patient> GetAllPatients()
        {
            List<Patient> allPatients = new List<Patient>();
            List<PatientDTO> dtos = Dal.GetAllPatients();

            foreach (PatientDTO dto in dtos)
            {
                Patient p = new Patient(
                    dto.ID,
                    dto.Name,
                    dto.Email,
                    dto.PhoneNumber,
                    dto.MedicalHistory,
                    dto.Doctor_ID);
                allPatients.Add(p);
            }

            return allPatients;
        }

    }
}
