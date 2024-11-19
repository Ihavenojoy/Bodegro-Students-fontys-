using Domain.Modules;
using Domain.ObjectConverter;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOConverter
{
    public class PatientDTOConverter
    {
        public PatientDTO ObjectToDTO(Patient patient)
        {
            return new PatientDTO
            {
                ID = patient.ID,
                Name = patient.Name,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                MedicalHistory = patient.MedicalHistory,
                Doctor_ID = patient.Doctor_ID
            };
        }
    }
}
