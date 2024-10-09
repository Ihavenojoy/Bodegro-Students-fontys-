using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectConverter
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
    }
}
