﻿using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOConverter
{
    public class DoctorDTOConverter
    {
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
