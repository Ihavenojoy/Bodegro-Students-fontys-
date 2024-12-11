using Domain.Converter;
using Domain.Modules;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MailServices
    {
        ISubscription SubDAL;
        SubscriptionConverter SubscriptionConverter;
        public MailServices(ISubscription subDAL)
        {
            SubscriptionConverter = new();
            SubDAL = subDAL;
        }
        public async Task<List<MailInfo>> GetNextStepDates()
        {
            List<MailInfo> infoForMails = new();
            List<SubscriptionDTO> subscriptions = await SubDAL.AsyncGetAll(); // Call the async database method

            foreach (var subscription in SubscriptionConverter.ListDTOToListObject(subscriptions))
            {
                int totalInterval = 0;
                int loopsTaken = 0;

                while (subscription.StartDate.AddDays(totalInterval) < DateTime.Now)
                {
                    for (int i = 0; i < subscription.Protocol.Steps.Count; i++)
                    {
                        if (subscription.StartDate.AddDays(totalInterval) < DateTime.Now)
                        {
                            totalInterval += subscription.Protocol.Steps[i].Interval;
                        }
                    }
                    loopsTaken++;

                    if (subscription.StartDate.AddDays(totalInterval) < DateTime.Now)
                    {
                        totalInterval = 365 * loopsTaken;
                    }
                }
                MailInfo mailInfo = new(subscription, subscription.StartDate.AddDays(totalInterval));
                infoForMails.Add(mailInfo);
            }

            return infoForMails;
        }
        public List<MailInfo> GetNextMailDates()
        {
            List<MailInfo> infoForMails = new();
            List<SubscriptionDTO> subscriptions = SubDAL.GetAll();

            foreach (var subscription in SubscriptionConverter.ListDTOToListObject(subscriptions))
            {
                int totalInterval = 0;
                int loopsTaken = 0;

                while (subscription.StartDate.AddDays(totalInterval) < DateTime.Now)
                {
                    for (int i = 0; i < subscription.Protocol.Steps.Count; i++)
                    {
                        if (subscription.StartDate.AddDays(totalInterval) < DateTime.Now)
                        {
                            totalInterval += subscription.Protocol.Steps[i].Interval;
                        }
                    }
                    loopsTaken++;

                    if (subscription.StartDate.AddDays(totalInterval) < DateTime.Now)
                    {
                        totalInterval = 365 * loopsTaken;
                    }
                }

                MailInfo mailInfo = new(subscription, subscription.StartDate.AddDays(totalInterval));
                infoForMails.Add(mailInfo);
            }
            return WeekCheck(infoForMails);
        }
        public List<MailInfo> WeekCheck(List<MailInfo> List)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].NextStepDay.AddDays(-7) > DateTime.Now)
                {
                    List.Remove(List[i]);
                    i--;
                }
            }
            return List;
        }
    }
}
