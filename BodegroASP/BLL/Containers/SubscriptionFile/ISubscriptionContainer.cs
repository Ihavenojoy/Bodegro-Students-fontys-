using Domain.Modules;

namespace Domain.Containers.SubscriptionFile
{
    public interface ISubscriptionContainer
    {
        string AddSubscription(Protocol protocol, Patient patient, DateTime SDate);
        bool Datumcheck(DateTime StartDate, DateTime EndDate);
    }
}