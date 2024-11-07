using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using Domain.Modules;

namespace BodegroTestPlan.BBL_Test.Modules_Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void SendEmailTest()
        {
            //Arange
            
            Email email = new Email("",EmailBody.TWOFACTOR);
            string emailSender = "bodegro.students.fontys@outlook.com";
            string emailReceiver = "Luuk.heesbeen@hotmail.com";
            string subject = "Testing the email";
            MailMessage mailMessage = email.MailMessage(emailSender, emailReceiver, subject);

            //Act
            bool emailsent = email.SendEmail(mailMessage);

            //Assert
            Assert.AreEqual(true, emailsent);
        }

        [TestMethod]
        public void MailMessage()
        {
            //Arange
            Email email = new Email();
            MailMessage mail = new MailMessage();
            string emailSender = "bodegro.students.fontys@outlook.com";
            string emailReceiver = "Luuk.heesbeen@hotmail.com";
            string subject =  "Testing the email";

            //Act
            mail = email.MailMessage(emailSender,emailReceiver,subject);

            //Assert
            Assert.AreEqual(emailSender, mail.From.Address);
            Assert.AreEqual(emailReceiver, mail.To[0].Address);
            Assert.AreEqual(subject, mail.Subject);
        }

        [TestMethod]
        public void TextSetup()
        {
            //Arange
            Email email = new Email();
            EmailBody Twofactor = EmailBody.TWOFACTOR;
            EmailBody Appointment = EmailBody.APPOINTMENT;
            string twofactorexpected = @"
    <h2>Your Two-Factor Authentication (2FA) Code</h2>
    <p>Dear <b>User</b>,</p>
    <p>To complete your login, please use the following authentication code:</p>
    <h1 style='color:blue;'>{{2FA_CODE}}</h1>
    <p>This code will expire in 10 minutes.</p>
    <p>If you did not request this code, please ignore this email or contact our support team.</p>
    <p>Best regards,<br/>Your Security Team</p>
";
            string appointmentexpected = @"
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

            //Act
            string checktwofactor = email.TextSetup(Twofactor);
            string Appointmet = email.TextSetup(Appointment);

            //Assert
            Assert.AreEqual(checktwofactor, twofactorexpected);
            Assert.AreEqual(Appointmet, appointmentexpected);
        }
    }
}
