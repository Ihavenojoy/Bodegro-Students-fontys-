using BLL.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BodegroInterfaces;
using BLL.ObjectConverter;
using BLL.DTOConverter;

namespace Domain.Containers
{
    public class SubscriptionContainer
    {
        ISubscription SubDAL;
        IPatient PatDal;
        IProtocol ProtDal;
        SubscriptionDTOConverter SubConverter = new();
        PatientConverter PatConverter = new();
        ProtocolConverter protConverter = new();
        private Doctor doctor;
        public SubscriptionContainer(Doctor doctor)
        {
            this.doctor = doctor;
            SubDAL = new SubscriptionDAL();
            PatDal = new PatientDAL();
            ProtDal = new ProtocolDAL();
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
            return protConverter.DTOToObjectList(ProtDal.GetAllProtocols());
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
            int SDay = StartDate.Day;
            int EDay = EndDate.Day;
            int SMonth = StartDate.Month;
            int EMonth = EndDate.Month;
            int SYear = StartDate.Year;
            int EYear = EndDate.Year;
            if (SDay <= EDay && SMonth <= EMonth && SYear <= EYear)
            {
                check = true;
            }
            else if (SMonth < EMonth && SYear <= EYear)
            {
                check = true;
            }
            else if (SYear < EYear)
            {
                check = true;
            }
            return check;
        }
        private string GetDate(string input, int min, int max)
        {
            string Date = "";
            for (int i = min; i <= max; i++)
            {
                char temp = input[i];
                Date += temp;
            }
            return Date;
        }
    }
}
