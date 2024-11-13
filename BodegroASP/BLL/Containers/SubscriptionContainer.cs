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
        {
            SubDAL = Sub;
        }
        public string AddSubscription(Protocol protocol, Patient patient, DateTime SDate)
        {
            Subscription subscription = new(SDate, protocol, patient);
            SubDAL.CreateSubscription(SubConverter.ObjectToDTO(subscription));
            return "Succesvol toegevoegt";
        }
    }
}
