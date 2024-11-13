using Domain.Enums;
using System.Net.Mail;

namespace Domain.Containers.EmailFile
{
    public interface IEmailContainer
    {
        MailMessage MailMessage(string emailReciever, EmailBody body);
        bool SendEmail(MailMessage message);
        string SubjectSetup(EmailBody body);
        string TextSetup(EmailBody body);
    }
}