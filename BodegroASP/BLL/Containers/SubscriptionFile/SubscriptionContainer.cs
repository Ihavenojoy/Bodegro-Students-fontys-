using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain.Converter;


namespace Domain.Containers.SubscriptionFile
{
    public class SubscriptionContainer : ISubscriptionContainer
    {
        ISubscription SubDAL;
        SubscriptionConverter subscriptionConverter =new();
        public SubscriptionContainer(User User, ISubscription Sub, IPatient Pat, IProtocol Prot)
        {
            SubDAL = Sub;
            this.subscriptionConverter = subscriptionConverter;
        }
        public string AddSubscription(Protocol protocol, Patient patient, DateTime SDate)
        {
            Subscription subscription = new(SDate, protocol, patient);
            SubDAL.CreateSubscription(subscriptionConverter.ObjectToDTO(subscription));
            return "Succesvol toegevoegt";
        }
    }
}
