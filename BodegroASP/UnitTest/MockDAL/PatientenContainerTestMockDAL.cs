using Domain.Modules;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;

namespace UnitTest.MockDAL
{
    public class PatientenContainerTestMockDAL : IPatient
    {
        private List<PatientDTO> patients = new List<PatientDTO>
        {
            new PatientDTO { ID = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = 1234567890, MedicalHistory = "No history", User_ID = 1 },
            new PatientDTO { ID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber = 9876543210, MedicalHistory = "Asthma", User_ID = 2 }
        };

        public bool CreatePatient(PatientDTO patient)
        {
            if (patient == null)
            {
                return false;
            }
            patients.Add(patient);
            return true;
        }

        public List<PatientDTO> Getall()
        {
            return new List<PatientDTO>(patients);
        }

        public List<PatientDTO> GetInactivePatients()
        {
            return new List<PatientDTO>(); // Returns an empty list for simplicity
        }

        public PatientDTO GetPatient(int id)
        {
            foreach (var patient in patients)
            {
                if (patient.ID == id)
                {
                    return patient;
                }
            }
            return null;
        }

        public PatientDTO GetPatientID(string email)
        {
            foreach (var patient in patients)
            {
                if (patient.Email == email)
                {
                    return patient;
                }
            }
            return null;
        }

        public List<int> GetPatientIDOfUser(int id)
        {
            List<int> patientIDs = new List<int>();
            foreach (var patient in patients)
            {
                if (patient.User_ID == id)
                {
                    patientIDs.Add(patient.ID);
                }
            }
            return patientIDs;
        }

        public bool SetActive(int id)
        {
            foreach (var patient in patients)
            {
                if (patient.ID == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
