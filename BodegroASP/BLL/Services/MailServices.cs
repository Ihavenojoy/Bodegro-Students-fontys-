using Domain.Containers.PatientFile;
using Domain.Containers.SubscriptionFile;
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
        SubscriptionConverter SubscriptionConverter;
        SubscriptionContainer _Subscriptionservice;
        PatientContainer _Patientservice;
        public MailServices(ISubscription subDAL, IPatient patientDAL)
        {
            SubscriptionConverter = new();
            _Subscriptionservice = new(subDAL);
            _Patientservice = new(patientDAL);
        }
        public async Task<List<MailInfo>> GetNextStepDates()
        {
            List<MailInfo> infoForMails = new();
            List<Subscription> subscriptions = await _Subscriptionservice.AsyncGetAll(); // Call the async database method

            foreach (var subscription in subscriptions)
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
            List<Subscription> subscriptions = _Subscriptionservice.GetAll();

            foreach (var subscription in subscriptions)
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
        public List<MailInfo> GetNextMailDates(User user)
        {
            List<MailInfo> infoForMails = new();
            List<Subscription> subscriptions = [];
            foreach (var PatientId in _Patientservice.GetPatientIDOfUser(user.ID))
            {
                foreach(var sub in _Subscriptionservice.GetSubscriptionsOfPatiënt(PatientId))
                {
                    subscriptions.Add(sub);
                }
            }
            _Patientservice.GetPatientIDOfUser(user.ID);

            foreach (var subscription in subscriptions)
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
