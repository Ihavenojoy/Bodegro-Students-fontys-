using BLL.Containers;
using BLL.Enums;
using BLL.Modules;
using BLL.ObjectConverter;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class PatientDTOConverter
    {
        private PatientDTO ObjectToDTO(Patient patient)
        {
            return new PatientDTO
            {
                Name = patient.Name,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                MedicalHistory = patient.MedicalHistory,
                Doctor_ID = patient.Doctor_ID
            };
        }
    }
}
