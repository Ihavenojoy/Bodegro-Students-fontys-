using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Enums;
using BLL.Modules;
using DTO;
using BLL.DTOConverter;
using BLL.ObjectConverter;

namespace BLL.Containers
{
    public class DoctorContainer
    {
        DoctorDTOConverter docConverter = new DoctorDTOConverter();
        DoctorConverter objectConverter = new DoctorConverter();
        DoctorDAL doctorDAL = new DoctorDAL();
        public int CreateDoctor(Doctor doctor)
        {
            if (doctorDAL.DoctorExists(doctor.Email))
            {
                return -1;
            }
            else
            {
                return doctorDAL.CreateDoctor(docConverter.ConvertToDTO(doctor), "");
            }
        }
        public bool DoctorExists(string email)
        {
            return doctorDAL.DoctorExists(email);
        }
        public bool DeleteDoctor(int doctorId)
        {
            bool isDeleted = doctorDAL.SoftDeleteDoctor(doctorId);
            if (!isDeleted)
            {
                return false;
            }
            return true;
        }

        
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new();
            List<DoctorDTO> doctorDTOS = doctorDAL.GetAllDoctors();

            foreach (DoctorDTO doctor in doctorDTOS)
            {
                doctors.Add(objectConverter.ConvertToDomain(doctor));
            }
            return doctors;
        }
    }
}
