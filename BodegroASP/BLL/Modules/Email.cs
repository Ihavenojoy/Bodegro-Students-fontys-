using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules
{
    public class Email
    {
        public MailMessage message {  get; set; }
        public EmailBody body {  get; set; }
        string receiver { get; set; }


        public Email(string emailreceiver, EmailBody emailBody)
        {
            message = new MailMessage();
            body = emailBody;
            receiver = emailreceiver;
        }
    }
}
