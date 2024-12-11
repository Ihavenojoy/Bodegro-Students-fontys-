using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.ViewConverter
{
    public class MailConvertert
    {
        SubscriptionConvertert SubscriptionConvertert { get; set; } = new SubscriptionConvertert();
        public List<EmailViewModel> ListObjectToVieuw(List<MailInfo> Objects)
        {
            List<EmailViewModel> returnlist = new List<EmailViewModel>();
            foreach (MailInfo mail in Objects)
            {
                EmailViewModel returnViewModel = new EmailViewModel
                {
                    Subscription = SubscriptionConvertert.ObjectToViewModel(mail.Subscription),
                    SendTime = mail.NextStepDay
                };
                returnlist.Add(returnViewModel);
            }
            return returnlist;
        }
    }
}
