using Domain.Containers.SubscriptionFile;

namespace BodegroASP.BackGroundServices.MailTask
{
    public class SubscriptionCheckerService : ISubscriptionCheckerService
    {
        private readonly ISubscriptionContainer _subscriptionContainer;

        public SubscriptionCheckerService(ISubscriptionContainer subscriptionContainer)
        {
            _subscriptionContainer = subscriptionContainer;
        }

        public async Task CheckConditionAsync()
        {
            var subscriptions = await _subscriptionContainer.GetNextStepDates();

            foreach (var mailinfo in subscriptions)
            {
                if (mailinfo.NextStepDay.Day == DateTime.Now.Day)
                {
                    mailinfo.Subscription.StepsTaken++;
                    //Send mail
                }
            }
        }
    }
}
