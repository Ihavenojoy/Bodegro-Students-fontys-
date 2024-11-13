using Domain.Enums;
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectConverter
{
    public class DoctorConverter
    {
        public Doctor DTOToObject(DoctorDTO dto)
        {
            Doctor doctor = new Doctor(
                dto.ID,
                dto.Name,
                dto.Email,
                (Regio)dto.Regio,
                dto.Admin_ID,
                dto.IsActive
            );
            return doctor;
        }
        public DoctorDTO ObjectToDTO(Doctor doctor)
        {
            return new DoctorDTO
            {
                ID = doctor.ID,
                Name = doctor.Name,
                Email = doctor.Email,
                IsActive = doctor.IsActive,
                Regio = (int)doctor.Regio,
                Admin_ID = doctor.Admin_ID
            };
        }
    }
}
