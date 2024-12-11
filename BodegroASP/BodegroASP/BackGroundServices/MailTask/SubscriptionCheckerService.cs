using DAL;
using Domain.Containers.EmailFile;
using Domain.Containers.SubscriptionFile;
using Domain.Services;
using System.Net.Mail;

namespace BodegroASP.BackGroundServices.MailTask
{
    public class SubscriptionCheckerService : ISubscriptionCheckerService
    {
        private readonly MailServices mailService;
        IConfiguration _configuration;

        public SubscriptionCheckerService(ISubscriptionContainer subscriptionContainer)
        {
            SubscriptionDAL subscriptionDAL = new(_configuration);
            mailService = new(subscriptionDAL);
        }
        EmailContainer EmailContainer = new EmailContainer();
        public async Task CheckConditionAsync()
        {
            var subscriptions = await mailService.GetNextStepDates();

            foreach (var mailinfo in subscriptions)
            {
                if (mailinfo.NextStepDay.Day == DateTime.Now.Day)
                {
                    mailinfo.Subscription.StepsTaken++;
                    MailMessage mailMessage = EmailContainer.MailMessage(mailinfo.Subscription.Patient.Email, Domain.Enums.EmailBody.APPOINTMENT, Convert.ToString(DateTime.Now.AddDays(7)));
                    EmailContainer.SendEmail(mailMessage);
                }
            }
        }
    }
}
