using Domain.Converter;
using Domain.Modules;
using Interfaces;

namespace Domain.Containers.PatientFile
{
    public class PatientContainer : IPatientContainer
    {
        private IPatient Dal;
        private PatientConverter objectconverter = new();
        public PatientContainer(IPatient dal)
        {
            Dal = dal;
        }
        public List<Patient> GetPatientsOfUser(User User)
        {
            List<Patient> list = new List<Patient>();
            List<int> PatientIDs = Dal.GetPatientIDOfUser(User.ID);
            foreach (int i in PatientIDs)
            {
                Patient patient = objectconverter.DTOToObject(Dal.GetPatient(i));
                list.Add(patient);
            }
            return list;
        }
        public Patient GetPatient(int id)
        {
            Patient patient = objectconverter.DTOToObject(Dal.GetPatient(id));
            return patient;
        }
        public Patient GetPatientID(string email)
        {
            Patient patient = objectconverter.DTOToObject(Dal.GetPatientID(email));
            return patient;
        }
        public List<int> GetPatientIDOfUser(int id)
        {
            return Dal.GetPatientIDOfUser(id);
        }
        public bool SetActive(int id)
        {
            return Dal.SetActive(id);
        }
        public List<Patient> GetInactivePatients()
        {
            List<Patient> patients = objectconverter.DTOListToObjectList(Dal.GetInactivePatients());
            return patients;
        }
        public List<Patient> GetAll()
        {
            return objectconverter.DTOListToObjectList(Dal.Getall());
        }
    }
}
