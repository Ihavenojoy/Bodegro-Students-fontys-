using Domain.Containers.EmailFile;
using Domain.Containers.SubscriptionFile;
using System.Net.Mail;

namespace BodegroASP.BackGroundServices.MailTask
{
    public class SubscriptionCheckerService : ISubscriptionCheckerService
    {
        private readonly ISubscriptionContainer _subscriptionContainer;

        public SubscriptionCheckerService(ISubscriptionContainer subscriptionContainer)
        {
            _subscriptionContainer = subscriptionContainer;
        }
        EmailContainer EmailContainer = new EmailContainer();
        public async Task CheckConditionAsync()
        {
            var subscriptions = await _subscriptionContainer.GetNextStepDates();

            foreach (var mailinfo in subscriptions)
            {
                if (mailinfo.NextStepDay.Day == DateTime.Now.Day)
                {
                    mailinfo.Subscription.StepsTaken++;
                    MailMessage mailMessage = EmailContainer.MailMessage(mailinfo.Subscription.Patient.Email, Domain.Enums.EmailBody.APPOINTMENT);
                    EmailContainer.SendEmail(mailMessage);
                }
            }
        }
    }
}
