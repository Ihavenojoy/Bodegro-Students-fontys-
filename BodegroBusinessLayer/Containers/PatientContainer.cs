using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Enums;
using BLL.Modules;
using BodegroInterfaces;
using DTO;

namespace BLL.Containers
{
    public class PatientContainer
    {
        private IPatient Dal = new PatientDAL();
        public List<Patient> AskAllPatientsOfDoctor(User user)
        {
            List<Patient> patients = new List<Patient>();
            //foreach loop met de database waar PatientDTO wordt opgehaald en wordt Convert waarna het in de list komt
            return patients;
        }
        private Patient DTOToObject(PatientDTO patientDTO)
        {
            Patient patient = new Patient(patientDTO.Name, patientDTO.Email, patientDTO.PhoneNumber, patientDTO.MedicalHistory, (Regio)patientDTO.Regio, patientDTO.Doctor_ID);
            return patient;
        }
        private PatientDTO ObjectToDTO(Patient patient)
        {
            PatientDTO patientDTO = new PatientDTO(patient.Name, patient.Email, patient.PhoneNumber, patient.MedicalHistory, (int)patient.Regio, patient.DoctorID);
            return patientDTO;
        }
    }
}
