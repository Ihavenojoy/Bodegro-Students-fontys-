using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using DTO;

namespace BLL.Containers
{
    public class AdminContainer
    {
        public Admin DTOtoObject(AdminDTO adminDTO)
        {
            Admin admin = new Admin
                (
                adminDTO.Email,
                adminDTO.Email
                );
            return admin;
        }

        public AdminDTO ObjectToDTO(Admin admin)
        {
            AdminDTO admindto = new AdminDTO
                (
                admin.Email,
                admin.Name
                );
            return admindto;
        }
    }
}
