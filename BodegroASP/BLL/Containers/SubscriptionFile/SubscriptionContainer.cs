using Domain.Converter;
using Domain.Modules;
using DTO;
using Interfaces;


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
    }
}
