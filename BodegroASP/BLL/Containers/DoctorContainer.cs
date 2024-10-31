using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using DTO;
using Domain.DTOConverter;
using Domain.ObjectConverter;
using Interfaces;

namespace Domain.Containers
{
    public class DoctorContainer
    {
        DoctorDTOConverter docConverter = new DoctorDTOConverter();
        DoctorConverter objectConverter = new DoctorConverter();
        DoctorDAL doctorDAL;
        private readonly IDoctor iDoctor = new DoctorDAL();
        public readonly ILogin _InlogService = new LoginDal();
        public DoctorContainer(DoctorDAL DAL) 
        {
            doctorDAL = DAL;
        }
        public int CreateDoctor(Doctor doctor, string password)
        {
            if (iDoctor.DoctorExists(doctor.Email))
            {
                return -1;
            }
            else
            {
                return iDoctor.CreateDoctor(docConverter.ObjectToDTO(doctor), password);
            }
        }
        public bool DoctorExists(string email)
        {
            return iDoctor.DoctorExists(email);
        }
        public bool DeleteDoctor(int doctorId)
        {
            bool isDeleted = iDoctor.SoftDeleteDoctor(doctorId);
            if (!isDeleted)
            {
                return false;
            }
            return true;
        }


        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new();
            List<DoctorDTO> doctorDTOS = iDoctor.GetAllDoctors();

            foreach (DoctorDTO doctor in doctorDTOS)
            {
                doctors.Add(objectConverter.ConvertToDomain(doctor));
            }
            return doctors;
        }


        public Doctor Login(string EmailInput, string PasswordInput)
        {
            DoctorDTO doctorDTO = _InlogService.DoctorLogin(EmailInput, PasswordInput);
            Doctor doctoracc = objectConverter.ConvertToDomain(doctorDTO);
            return doctoracc;
        }
    }
}
