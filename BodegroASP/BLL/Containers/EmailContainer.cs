using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Domain.Modules;

namespace Domain.Containers
{
    public class EmailContainer
    {
        public bool SendEmail(MailMessage message)
        {
            bool isDone = false;
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    NetworkCredential credentials = new NetworkCredential("no.reply.grodebo@gmail.com", "urff rjxk arsw ywqg");
                    client.EnableSsl = true;
                    client.Credentials = credentials;

                    client.Send(message);
                    isDone = true;
                }
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Error: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return isDone;
        }



        public MailMessage MailMessage(string emailReciever, EmailBody body)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("no.reply.grodebo@gmail.com");
            mail.To.Add(emailReciever);
            mail.Subject = SubjectSetup(body);
            mail.Body = TextSetup(body);
            mail.IsBodyHtml = true;


            return mail;
        }

        public string TextSetup(EmailBody body)
        {
            switch (body)
            {
                case EmailBody.TWOFACTOR:
                    return @"
                <h2>Your Two-Factor Authentication (2FA) Code</h2>
                <p>Dear <b>User</b>,</p>
                <p>To complete your login, please use the following authentication code:</p>
                <h1 style='color:blue;'>{{2FA_CODE}}</h1>
                <p>This code will expire in 10 minutes.</p>
                <p>If you did not request this code, please ignore this email or contact our support team.</p>
                <p>Best regards,<br/>Your Security Team</p>
            ";

                case EmailBody.APPOINTMENT:
                    return @"
                <h2>Appointment Confirmation</h2>
                <p>Dear <b>{{USER_NAME}}</b>,</p>
                <p>Your appointment has been scheduled as follows:</p>
                <p><b>Date:</b> {{APPOINTMENT_DATE}}</p>
                <p><b>Time:</b> {{APPOINTMENT_TIME}}</p>
                <p><b>Location:</b> {{APPOINTMENT_LOCATION}}</p>
                <p>If this is a virtual appointment, use the following link to join:</p>
                <p><a href='{{APPOINTMENT_LINK}}'>Join Appointment</a></p>
                <p>Please contact us if you need to reschedule or have any questions.</p>
                <p>Best regards,<br/>{{COMPANY_NAME}}</p>
            ";

                default:
                    return "Template not found";
            }
        }


        public string SubjectSetup(EmailBody body)
        {
            switch (body)
            {
                case EmailBody.TWOFACTOR:
                    return "Two Factor code";

                case EmailBody.APPOINTMENT:
                    return "Appointment";

                default:
                    return "Subject not found";
            }
        }

    }
}
