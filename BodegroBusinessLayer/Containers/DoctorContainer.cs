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
        DoctorDAL doctorDAL = new DoctorDAL();
        public int CreateDoctor(Doctor doctor)
        {
            if (doctorDAL.DoctorExists(doctor.Email))
            {
                return -1;
            }
            else
            {
                return doctorDAL.CreateDoctor(ConvertToDTO(doctor));
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

        private DoctorDTO ConvertToDTO(Doctor doctor)
        {
            return new DoctorDTO
            {
                Name = doctor.Name,
                Email = doctor.Email,
                IsActive = doctor.IsActive,
                Regio = doctor.Regio,
                Admin_ID = doctor.Admin_ID
            };
        }
        private Doctor ConvertToDomain(DoctorDTO dto)
        {
            Doctor doctor = new(dto.ID, dto.Name, dto.Email, dto.IsActive, dto.Regio, dto.Admin_ID);
            return doctor;

        }
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new();
            List<DoctorDTO> doctorDTOS = doctorDAL.GetAllDoctors();

            foreach (DoctorDTO doctor in doctorDTOS)
            {
                doctors.Add(ConvertToDomain(doctor));
            }
            return doctors;
        }
    }
}
