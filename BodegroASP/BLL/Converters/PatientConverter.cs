
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converter
{
    public class PatientConverter
    {
        public Patient DTOToObject(PatientDTO patientDTO)
        {
            Patient patient = new Patient(
                patientDTO.ID,
                patientDTO.Name,
                patientDTO.Email,
                patientDTO.PhoneNumber,
                patientDTO.MedicalHistory,
                patientDTO.User_ID);
            return patient;
        }
        public List<Patient> DTOListToObjectList(List<PatientDTO> patientDTOs)
        {
            List<Patient> list = [];
            foreach (var patientdto in patientDTOs)
            {
                Patient patient = new Patient(
                    patientdto.ID,
                    patientdto.Name,
                    patientdto.Email,
                    patientdto.PhoneNumber,
                    patientdto.MedicalHistory,
                    patientdto.User_ID);
                list.Add(patient);
            }
            return list;
        }
        public PatientDTO ObjectToDTO(Patient patient)
        {
            return new PatientDTO
            {
                ID = patient.ID,
                Name = patient.Name,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                MedicalHistory = patient.MedicalHistory,
                User_ID = patient.User_ID
            };
        }
        public List<Patient> ListDTOToObject(List<PatientDTO> dto)
        {
            List<Patient> list = new List<Patient>();
            foreach (PatientDTO patientDTO in dto)
            {
                Patient patient = new Patient(
                    patientDTO.ID,
                    patientDTO.Name,
                    patientDTO.Email,
                    patientDTO.PhoneNumber,
                    patientDTO.MedicalHistory,
                    patientDTO.User_ID);
                list.Add(patient);
            }
            return list;
        }
    }
}
