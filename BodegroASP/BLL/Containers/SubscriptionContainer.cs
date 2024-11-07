using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Interfaces;
using Domain.ObjectConverter;
using Domain.DTOConverter;

namespace Domain.Containers
{
    public class SubscriptionContainer
    {
        ISubscription SubDAL;
        IPatient PatDal;
        IProtocol ProtDal;
        SubscriptionDTOConverter SubConverter = new();
        PatientConverter PatConverter = new();
        ProtocolConverter ProtConverter = new();
        private Doctor doctor;
        public SubscriptionContainer(Doctor doctor, ISubscription Sub, IPatient Pat, IProtocol Prot)
        {
            this.doctor = doctor;
            SubDAL = Sub;
            PatDal = Pat;
            ProtDal = Prot;
        }
        public List<Patient> GetPatients()
        {
            List<Patient> list = new List<Patient>();
            List<int> PatientIDs = PatDal.GetPatientIDOfDoctor(doctor.ID);
            for (int i = 0; i < PatientIDs.Count; i++)
            {
                list.Add(PatConverter.DTOToObject(PatDal.GetPatient(PatientIDs[i], doctor.ID)));
            }
            return list;
        }
        public List<Protocol> GetProtocols()
        {
            return ProtConverter.ListDTOToListObject(ProtDal.GetAllProtocols());
        }
        public string AddSubscription(Protocol protocol, Patient patient, DateTime SDate)
        {
            Subscription subscription = new(SDate, protocol, patient);
            SubDAL.CreateSubscription(SubConverter.ObjectToDTO(subscription));
            return "Succesvol toegevoegt";
        }
        public bool Datumcheck(DateTime StartDate, DateTime EndDate)
        {
            bool check = false;
            if (StartDate.Year < EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Month < EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Day < EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Hour < EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Minute < EndDate.Minute && StartDate.Hour <= EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Second < EndDate.Second && StartDate.Minute <= EndDate.Minute && StartDate.Hour <= EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            return check;
        }
    }
}
