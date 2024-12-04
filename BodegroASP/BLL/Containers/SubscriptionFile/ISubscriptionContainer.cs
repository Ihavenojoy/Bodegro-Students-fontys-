using Domain.Modules;

namespace Domain.Containers.SubscriptionFile
{
    public interface ISubscriptionContainer
    {
        bool AddSubscription(Protocol protocol, Patient patient, DateTime SDate);
        public List<Subscription> GetSubscriptionsOfPatiënt(int patientID);
        public bool DeleteSubscription(int id);
        public Task<List<MailInfo>> GetNextStepDates();
    }
}