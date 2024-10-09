﻿using BLL.Enums;
using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectConverter
{
    public class DoctorConverter
    {
        private Doctor ConvertToDomain(DoctorDTO dto)
        {
            Doctor doctor = new(
                dto.ID,
                dto.Name,
                dto.Email,
                (Regio)dto.Regio,
                dto.Admin_ID,
                dto.IsActive
            );
            return doctor;
        }
    }
}
