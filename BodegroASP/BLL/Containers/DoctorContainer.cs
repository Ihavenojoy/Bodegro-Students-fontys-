﻿using System;
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
using System.Data;

namespace Domain.Containers
{
    public class DoctorContainer
    {
        DoctorDTOConverter docConverter = new DoctorDTOConverter();
        DoctorConverter objectConverter = new DoctorConverter();
        IDoctor doctorDAL;
        public DoctorContainer(IDoctor DAL) 
        {
            doctorDAL = DAL;
        }
        public int CreateDoctor(Doctor doctor, string password)
        {
            if (doctorDAL.DoctorExists(doctor.Email))
            {
                return -1;
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
                doctors.Add(objectConverter.DTOToObject(doctor));
            }
            return doctors;
        }


        
    }
}
