using BLL.Enums;
using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class DoctorDTOConverter
    {
        private DoctorDTO ConvertToDTO(Doctor doctor)
        {
            return new DoctorDTO
            (
                doctor.ID,
                doctor.Name,
                doctor.Email,
                doctor.IsActive,
                (int)doctor.Regio,
                doctor.AdminId
            );
        }
    }
}
