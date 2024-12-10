using Domain.Modules;

namespace Domain.Containers.SubscriptionFile
{
    public interface ISubscriptionContainer
    {
        bool AddSubscription(Protocol protocol, Patient patient, DateTime SDate);
    }
}