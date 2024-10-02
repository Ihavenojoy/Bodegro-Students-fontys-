using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BodegroBusinessLayer
{
    internal class Email
    {
        public bool SendEmail(MailMessage message)
        {
            bool isDone = false;
            try
            {
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential("bodegro.students.fontys@outlook.com", "Grodebo123");
                client.EnableSsl = true;               
               
                client.Send(message);
                isDone = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed because " + ex);
            }

            return isDone;
        }


        public MailMessage MailMessage(string emailSender, string emailReciever, string Subject)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(emailSender);
            mail.To.Add(emailReciever);
            mail.Subject = Subject;




            return mail;
        }
    }
}
