using Domain.Containers.EmailFile;
using Domain.Enums;
using System.Net.Mail;

[TestClass]
public class EmailContainerTest
{
    private EmailContainer _emailContainer;

    [TestInitialize]
    public void Setup()
    {
        _emailContainer = new EmailContainer();
    }

    [TestMethod]
    public void SendEmail_Success()
    {
        var message = new MailMessage("no.reply.grodebo@gmail.com", "test@example.com")
        {
            Subject = "Test Email",
            Body = "This is a test email."
        };

        var result = _emailContainer.SendEmail(message);

        Assert.IsTrue(result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void SendEmail_FormatException()
    {
        var message = new MailMessage("no.reply.grodebo@gmail.com", "invalid-email")
        {
            Subject = "Test Email",
            Body = "This is a test email."
        };

        _emailContainer.SendEmail(message);
    }

    [TestMethod]
    public void MailMessage_Success()
    {
        var emailReceiver = "test@example.com";
        var body = EmailBody.TWOFACTOR;
        var sendString = "123456";

        var mailMessage = _emailContainer.MailMessage(emailReceiver, body, sendString);

        Assert.IsNotNull(mailMessage);
        Assert.AreEqual("no.reply.grodebo@gmail.com", mailMessage.From.Address);
        Assert.AreEqual(emailReceiver, mailMessage.To[0].Address);
        Assert.AreEqual("Two Factor Code", mailMessage.Subject);
        Assert.IsTrue(mailMessage.Body.Contains(sendString));
    }

    [TestMethod]
    public void MailMessage_InvalidEmailFormat()
    {
        var emailReceiver = "invalid-email";
        var body = EmailBody.TWOFACTOR;
        var sendString = "123456";

        try
        {
            var mailMessage = _emailContainer.MailMessage(emailReceiver, body, sendString);
            Assert.Fail("Expected FormatException but none was thrown.");
        }
        catch (Exception ex)
        {
            Assert.AreEqual("The specified string is not in the form required for an e-mail address.", ex.Message);
        }
    }

    [TestMethod]
    public void TextSetup_TwoFactor()
    {
        var body = EmailBody.TWOFACTOR;
        var sendString = "123456";

        var result = _emailContainer.TextSetup(body, sendString);

        Assert.IsTrue(result.Contains("Your Two-Factor Authentication (2FA) Code"));
        Assert.IsTrue(result.Contains(sendString));
    }

    [TestMethod]
    public void TextSetup_Appointment()
    {
        var body = EmailBody.APPOINTMENT;
        var sendString = "2025-01-15";

        var result = _emailContainer.TextSetup(body, sendString);

        Assert.IsTrue(result.Contains("Appointment Confirmation"));
        Assert.IsTrue(result.Contains(sendString));
    }

    [TestMethod]
    public void TextSetup_InvalidBodyType()
    {
        var body = (EmailBody)999;
        var sendString = "123456";

        var result = _emailContainer.TextSetup(body, sendString);

        Assert.AreEqual("An error occurred while generating the email content.", result);
    }

    [TestMethod]
    public void SubjectSetup_TwoFactor()
    {
        var body = EmailBody.TWOFACTOR;

        var result = _emailContainer.SubjectSetup(body);

        Assert.AreEqual("Two Factor Code", result);
    }

    [TestMethod]
    public void SubjectSetup_Appointment()
    {
        var body = EmailBody.APPOINTMENT;

        var result = _emailContainer.SubjectSetup(body);

        Assert.AreEqual("Appointment", result);
    }

    [TestMethod]
    public void SubjectSetup_InvalidBodyType()
    {
        var body = (EmailBody)999;

        var result = _emailContainer.SubjectSetup(body);

        Assert.AreEqual("Error: Subject not found", result);
    }
}
