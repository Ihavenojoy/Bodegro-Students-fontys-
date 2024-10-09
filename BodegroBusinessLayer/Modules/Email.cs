using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BLL.Modules
{
    public class Email
    {
        public bool SendEmail(MailMessage message)
        {
            bool isDone = false;
            try
            {
                using (SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587))
                {
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    // Hardcoded credentials (less secure way)
                    NetworkCredential credentials = new NetworkCredential("bodegro.students.fontys@outlook.com", "nkgl uupe dtuw mqhz");
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



        public MailMessage MailMessage(string emailSender, string emailReciever, string Subject)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(emailSender);
            mail.To.Add(emailReciever);
            mail.Subject = Subject;
            mail.Body = "Test123";
            mail.IsBodyHtml = true;


            return mail;
        }

        public string TextSetup(EmailBody body)
        {
            string setup = "";

            switch(body)
            {
                case EmailBody.TWOFACTOR:
                    setup = @"
    <h2>Your Two-Factor Authentication (2FA) Code</h2>
    <p>Dear <b>User</b>,</p>
    <p>To complete your login, please use the following authentication code:</p>
    <h1 style='color:blue;'>{{2FA_CODE}}</h1>
    <p>This code will expire in 10 minutes.</p>
    <p>If you did not request this code, please ignore this email or contact our support team.</p>
    <p>Best regards,<br/>Your Security Team</p>
";
                    break;

                case EmailBody.APPOINTMENT:
                    setup = @"
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
                    break;
            }

            return setup;
        }
    }
}
