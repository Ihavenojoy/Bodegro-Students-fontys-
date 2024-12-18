using DAL;
using Domain.Containers.PatientFile;
using Domain.Modules;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SearchService
    {
        PatientContainer PatientContainer { get; set; }
        MailServices MailServices { get; set; }
        public SearchService(IPatient patient, ISubscription subscription)
        {
            PatientContainer = new(patient);
            MailServices = new(subscription, patient);
        }
        public List<MailInfo> SearchMail(string name)
        {
            List<MailInfo> returnList = new List<MailInfo>();
            foreach (var Mail in MailServices.GetNextMailDates())
            {
                if (Mail.Subscription.Patient.Name != null && Mail.Subscription.Patient.Name.Contains(name))
                {
                    returnList.Add(Mail);
                }
            }
            return returnList;
        }
        public List<MailInfo> SearchMail(string name, User user)
        {
            List<MailInfo> returnList = new List<MailInfo>();
            foreach (var Mail in MailServices.GetNextMailDates(user))
            {
                if (Mail.Subscription.Patient.Name != null && Mail.Subscription.Patient.Name.Contains(name))
                {
                    returnList.Add(Mail);
                }
            }
            return returnList;
        }
        public List<Patient> SearchPatient(string name, User user)
        {
            List<Patient> returnList = new List<Patient>();
            foreach (var Patient in PatientContainer.GetPatientsOfUser(user))
            {
                if (Patient.Name != null && Patient.Name.Contains(name))
                {
                    returnList.Add(Patient);
                }
            }
            return returnList;
        }
    }
}
