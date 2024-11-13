﻿using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectConverter
{
    public class AdminConverter
    {
        public Admin DTOToObject(AdminDTO adminDTO)
        {
            Admin admin = new Admin
            (
                adminDTO.ID,
                adminDTO.Name,
                adminDTO.Email
            );
            return admin;
        }
        public AdminDTO ObjectToDTO(Admin admin)
        {
            AdminDTO admindto = new AdminDTO
            {
                ID = admin.ID,
                Name = admin.Name,
                Email = admin.Email
            };
            return admindto;
        }
    }
}
