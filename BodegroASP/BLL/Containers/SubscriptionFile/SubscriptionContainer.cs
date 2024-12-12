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
        public List<Subscription> GetAll()
        {
            return subscriptionConverter.ListDTOToListObject(SubDAL.GetAll());
        }
        public async Task<List<Subscription>> AsyncGetAll()
        {
            var subscriptionDTOs = await SubDAL.AsyncGetAll();
            var subscriptions = subscriptionConverter.ListDTOToListObject(subscriptionDTOs);
            return subscriptions;
        }

    }
}
