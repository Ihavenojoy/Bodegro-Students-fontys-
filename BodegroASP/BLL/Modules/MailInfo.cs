using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules
{
    public class MailInfo
    {
        public Subscription Subscription { get; private set; }
        public DateTime NextStepDay { get; private set; }
        public MailInfo(Subscription subscription, DateTime nextStepDay)
        {
            Subscription = subscription;
            NextStepDay = nextStepDay;
        }
    }
}
