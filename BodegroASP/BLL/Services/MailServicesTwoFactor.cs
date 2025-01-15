using Domain.Containers.EmailFile;
using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twofactor;

namespace Domain.Services
{
    public class MailServicesTwoFactor
    {
        EmailContainer EmailContainer = new EmailContainer();
        public bool SentTwofactor(string OTP, string email)
        {
            string code = Generate.OTP(OTP);
            MailMessage mailMessage = EmailContainer.MailMessage(email, Domain.Enums.EmailBody.TWOFACTOR, code);
            return EmailContainer.SendEmail(mailMessage);

        }
    }
}
