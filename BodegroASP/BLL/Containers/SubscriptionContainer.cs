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
        SubscriptionDTOConverter SubConverter = new();
        public SubscriptionContainer(Doctor doctor, ISubscription Sub, IPatient Pat, IProtocol Prot)
        {// doctor, sub, pat en prot kunnen weg als we weeg allemaal gemerged zijn
            SubDAL = Sub;
        }
        public void AddSubscription(Protocol protocol, Patient patient, DateTime SDate)
        {
            Subscription subscription = new(SDate, protocol, patient);
            SubDAL.CreateSubscription(SubConverter.ObjectToDTO(subscription));
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
