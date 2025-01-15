using System;
using System.Net.Mail;
using System.Net;
using Domain.Modules;
using Domain.Enums;
using Microsoft.Identity.Client;

namespace Domain.Containers.EmailFile
{
    public class EmailContainer : IEmailContainer
    {
        public SmtpClient client {  get; set; }

        public EmailContainer()
        {
            client = new SmtpClient();
        }
        public bool SendEmail(MailMessage message)
        {
            
            bool isDone = false;
            try
            {
                using (client = new SmtpClient("smtp.gmail.com", 587))
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
            catch (SmtpFailedRecipientException ex)
            {
                Console.WriteLine($"Failed to deliver email to a recipient: {ex.Message}");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while sending the email: {ex.Message}");
            }

            return isDone;
        }

        public MailMessage MailMessage(string emailReciever, EmailBody body, string sendString)
        {
            MailMessage mail = null;

            try
            {
                mail = new MailMessage
                {
                    From = new MailAddress("no.reply.grodebo@gmail.com"),
                    Subject = SubjectSetup(body),
                    Body = TextSetup(body, sendString),
                    IsBodyHtml = true
                };

                mail.To.Add(emailReciever);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error creating email message: A required parameter was null. {ex.Message}");
                throw; 
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error creating email message: Invalid email format. {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while creating the email message: {ex.Message}");
                throw;
            }

            return mail;
        }


        public string TextSetup(EmailBody body, string sendString)
        {
            string result = "An error occurred while generating the email content.";

            try
            {
                switch (body)
                {
                    case EmailBody.TWOFACTOR:
                        result = @$"
                            <h2>Your Two-Factor Authentication (2FA) Code</h2>
                            <p>Dear <b>User</b>,</p>
                            <p>To complete your login, please use the following authentication code:</p>
                            <h1 style='color:blue;'>{sendString}</h1>
                            <p>This code will expire in 10 minutes.</p>
                            <p>If you did not request this code, please ignore this email or contact our support team.</p>
                            <p>Best regards,<br/>Your Security Team</p>
                        ";
                        break;

                    case EmailBody.APPOINTMENT:
                        result = @$"
                            <h2>Appointment Confirmation</h2>
                            <p>Dear <b>Patient</b>,</p>
                            <p>With this e-mail we remind you to make a new appointment at your nearest medical facility.</p>
                            <p>As of today, we will be expecting a new request for an appointment from you.</p>
                            <p>You have until the date below to make an appointment:</p>
                            <p><b>Date:</b> {sendString}</p>
                            <p>Please contact us if you need to reschedule or have any questions.</p>
                            <p>Best regards,<br/>Bodegro</p>
                        ";
                        break;

                    default:
                        throw new ArgumentException("Invalid EmailBody type provided.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up email text: {ex.Message}");
            }

            return result;
        }

        public string SubjectSetup(EmailBody body)
        {
            string result = "Error: Subject not found";

            try
            {
                result = body switch
                {
                    EmailBody.TWOFACTOR => "Two Factor Code",
                    EmailBody.APPOINTMENT => "Appointment",
                    _ => throw new ArgumentException("Invalid EmailBody type provided.")
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up email subject: {ex.Message}");
            }

            return result;
        }
    }
}
