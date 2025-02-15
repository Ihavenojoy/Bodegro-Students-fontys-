﻿using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.Converters
{
    public class PatientConvertert
    {
        public List<PatientViewModel> ListObjectToVieuw(List<Patient> patients)
        {
            List<PatientViewModel> list = new List<PatientViewModel>();
            foreach (Patient patient in patients)
            {
                PatientViewModel temp = new PatientViewModel()
                {
                    ID = patient.ID,
                    Email = patient.Email,
                    MedicalHistory = patient.MedicalHistory,
                    Name = patient.Name,
                    PhoneNumber = patient.PhoneNumber
                };
                list.Add(temp);
            }
            return list;
        }
        public PatientViewModel ObjectToVieuw(Patient patient)
        {

            PatientViewModel temp = new PatientViewModel()
            {
                ID = patient.ID,
                Email = patient.Email,
                MedicalHistory = patient.MedicalHistory,
                Name = patient.Name,
                PhoneNumber = patient.PhoneNumber
            };
            return temp;
        }
        public Patient ViewToObject(PatientViewModel view)
        {
            return new Patient(view.Name, view.Email, view.PhoneNumber, view.MedicalHistory, 0);
        }
    }
}
