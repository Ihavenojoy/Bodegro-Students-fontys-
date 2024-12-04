using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain.Converter;
using DTO;


namespace Domain.Containers.SubscriptionFile
{
    public class SubscriptionContainer : ISubscriptionContainer
    {
        ISubscription SubDAL;
        SubscriptionConverter subscriptionConverter = new();
        public SubscriptionContainer(ISubscription Sub)
        {
            SubDAL = Sub;
            this.subscriptionConverter = subscriptionConverter;
        }
        public bool AddSubscription(Protocol protocol, Patient patient, DateTime SDate)
        {
            Subscription subscription = new(SDate, protocol, patient);
            return SubDAL.CreateSubscription(subscriptionConverter.ObjectToDTO(subscription));
        }
        public List<Subscription> GetSubscriptionsOfPatiënt(int patientID)
        {
            return subscriptionConverter.ListDTOToListObject(SubDAL.GetSubscriptionsOfPatiënt(patientID));
        }
        public bool DeleteSubscription(int id)
        {
            return SubDAL.SoftDeleteSubscription(id);
        }
        public async Task<List<MailInfo>> GetNextStepDates()
        {
            List<MailInfo> infoForMails = new();
            List<SubscriptionDTO> subscriptions = await SubDAL.GetAll(); // Call the async database method

            foreach (var subscription in subscriptionConverter.ListDTOToListObject(subscriptions))
            {
                int totalInterval = 0;

                for (int i = 0; i < subscription.StepsTaken; i++)
                {
                    totalInterval += subscription.Protocol.Steps[i].Interval;
                }

                MailInfo mailInfo = new(subscription, subscription.StartDate.AddDays(totalInterval));
                infoForMails.Add(mailInfo);
            }

            return infoForMails; 
        }
    }
}
