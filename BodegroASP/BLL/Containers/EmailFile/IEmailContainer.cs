using Domain.Enums;
using System.Net.Mail;

namespace Domain.Containers.EmailFile
{
    public interface IEmailContainer
    {
        MailMessage MailMessage(string emailReciever, EmailBody body, string SendString);
        bool SendEmail(MailMessage message);
        string SubjectSetup(EmailBody body);
        string TextSetup(EmailBody body, string sendString);
    }
}