using Domain.Containers.EmailFile;
using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MailServicesTwoFactor
    {
        EmailContainer EmailContainer = new EmailContainer();
        public bool SentTwofactor(string OTP, string email)
        {
            MailMessage mailMessage = EmailContainer.MailMessage(email, Domain.Enums.EmailBody.TWOFACTOR, OTP);
            return EmailContainer.SendEmail(mailMessage);

        }
    }
}
