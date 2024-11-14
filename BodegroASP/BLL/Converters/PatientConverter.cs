
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
    }
}
