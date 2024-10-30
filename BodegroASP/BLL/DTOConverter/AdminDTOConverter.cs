using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class AdminDTOConverter
    {
        public AdminDTO ObjectToDTO(Admin admin)
        {
            AdminDTO admindto = new AdminDTO
            {                 
                ID =admin.ID,
                Name = admin.Name,
                Email = admin.Email
            };
            return admindto;
        }
    }
}
