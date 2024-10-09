using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Enums;
using BLL.Modules;
using DTO;

namespace BLL.Containers
{
    public class DoctorContainer
    {
        public Doctor DTOtoObject(DoctorDTO doctordto)
        {
            Doctor doctor = new Doctor
                (
                doctordto.Name,
                doctordto.Email,
                (Regio)doctordto.Regio
                );
            return doctor;
        }

        public DoctorDTO ObjectToDTO(Doctor doctor)
        {
            DoctorDTO doctordto = new DoctorDTO
                (
                doctor.Name,
                doctor.Email,
                (int)doctor.Regio
                );
            return doctordto;
        }
    }
}
