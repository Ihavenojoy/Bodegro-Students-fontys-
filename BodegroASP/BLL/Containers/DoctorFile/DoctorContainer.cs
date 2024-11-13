using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using DTO;
using Domain.ObjectConverter;
using Interfaces;
using System.Data;

namespace Domain.Containers.DoctorFile
{
    public class DoctorContainer : IDoctorContainer
    {
        DoctorConverter docConverter;
        IDoctor doctorDAL;
        public DoctorContainer(IDoctor DAL, DoctorConverter docConverter)
        {
            doctorDAL = DAL;
            this.docConverter = docConverter;
        }
        public bool CreateDoctor(Doctor doctor, string password)
        {
            if (doctorDAL.DoctorExists(doctor.Email))
            {
                return false;
            }
            else
            {
                return doctorDAL.CreateDoctor(docConverter.ObjectToDTO(doctor), password);
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
                doctors.Add(docConverter.DTOToObject(doctor));
            }
            return doctors;
        }



    }
}
