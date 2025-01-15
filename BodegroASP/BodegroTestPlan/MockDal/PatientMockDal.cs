using DAL;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.MockDal
{
    public class MockPatientDAL : IPatient
    {
        private List<PatientDTO> patientlist;
        public List<PatientDTO> MockDTOList;
        public List<int> MockIntList;

        public bool success = true;

        public MockPatientDAL()
        {
            MockIntList = new();
            patientlist = new List<PatientDTO>
        {
            new PatientDTO { ID = 1, Name = "John Doe", PhoneNumber = 1234567890, Email = "john@example.com", MedicalHistory = "None", User_ID = 1 },
            new PatientDTO { ID = 2, Name = "Jane Smith", PhoneNumber = 986543210, Email = "jane@example.com", MedicalHistory = "Asthma", User_ID = 2 },
            new PatientDTO { ID = 3, Name = "Samuel Green", PhoneNumber = 1122334455, Email = "samuel@example.com", MedicalHistory = "Diabetes", User_ID = 1 },
        };
        }


        public bool CreatePatient(PatientDTO patient)
        {
            MockDTOList.Add(patient);
            return success;
        }

        public List<PatientDTO> Getall()
        {
            return patientlist; 
        }

        public List<PatientDTO> GetInactivePatients()
        {
            return patientlist;
        }


        public PatientDTO GetPatient(int id)
        {
            MockDTOList.Add(patientlist[0]);
            return patientlist[0];
        }

        public PatientDTO GetPatientID(string email)
        {
            MockDTOList.Add(patientlist[0]);
            return patientlist[0];
        }

        public List<int> GetPatientIDOfUser(int id)
        {
            List<int> ints = new List<int>() { 6, 2, 63, 7, 2, 3, 6, 2 };
            MockIntList = ints;
            return ints;
        }

        public bool SetActive(int id)
        {
            MockIntList.Add(id);
            return success;
        }
    }

}
