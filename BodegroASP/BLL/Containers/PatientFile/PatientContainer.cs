using System;
using System.Collections.Generic;
using DAL;
using Domain.Modules;
using Interfaces;
using DTO;
using Domain.Converter;

namespace Domain.Containers.PatientFile
{
    public class PatientContainer : IPatientContainer
    {
        private readonly IPatient Dal;
        private readonly PatientConverter objectconverter = new();

        public PatientContainer(IPatient dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("DAL cannot be null");
            }
            Dal = dal;
        }

        public List<Patient> GetPatientsOfUser(User user)
        {
            List<Patient> list = new List<Patient>();

            if (user == null)
            {
                Console.WriteLine("User cannot be null");
            }
            else
            {
                try
                {
                    List<int> patientIDs = Dal.GetPatientIDOfUser(user.ID);
                    foreach (int id in patientIDs)
                    {
                        PatientDTO dto = Dal.GetPatient(id);
                        if (dto != null)
                        {
                            Patient patient = objectconverter.DTOToObject(dto);
                            list.Add(patient);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong while getting patients of the user: " + ex.Message);
                }
            }

            return list;
        }

        public Patient GetPatient(int id)
        {
            Patient patient = null;

            try
            {
                PatientDTO dto = Dal.GetPatient(id);
                if (dto != null)
                {
                    patient = objectconverter.DTOToObject(dto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting patient: " + ex.Message);
            }

            return patient;
        }

        public Patient GetPatientID(string email)
        {
            Patient patient = null;

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty");
            }
            else
            {
                try
                {
                    PatientDTO dto = Dal.GetPatientID(email);
                    if (dto != null)
                    {
                        patient = objectconverter.DTOToObject(dto);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting patient by email: " + ex.Message);
                }
            }

            return patient;
        }

        public List<int> GetPatientIDOfUser(int id)
        {
            List<int> ids = new List<int>();

            try
            {
                ids = Dal.GetPatientIDOfUser(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting patient IDs for user: " + ex.Message);
            }

            return ids;
        }

        public bool SetActive(int id)
        {
            bool success = false;

            try
            {
                success = Dal.SetActive(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting patient as active: " + ex.Message);
            }

            return success;
        }

        public List<Patient> GetInactivePatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                List<PatientDTO> dtos = Dal.GetInactivePatients();
                patients = objectconverter.DTOListToObjectList(dtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting inactive patients: " + ex.Message);
            }

            return patients;
        }

        public List<Patient> GetAll()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                List<PatientDTO> dtos = Dal.Getall();
                patients = objectconverter.DTOListToObjectList(dtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting all patients: " + ex.Message);
            }

            return patients;
        }

        public bool AddPatient(Patient patient)
        {
            bool success = false;

            if (patient == null)
            {
                Console.WriteLine("Patient cannot be null");
            }
            else
            {
                try
                {
                    success = Dal.CreatePatient(objectconverter.ObjectToDTO(patient));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding patient: " + ex.Message);
                }
            }

            return success;
        }
    }
}
