﻿using Domain.Modules;

namespace Domain.Containers
{
    public interface IDoctorContainer
    {
        bool CreateDoctor(Doctor doctor, string password);
        bool DeleteDoctor(int doctorId);
        bool DoctorExists(string email);
        List<Doctor> GetAllDoctors();
    }
}