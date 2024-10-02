using Microsoft.Identity.Client;
using Microsoft.Graph;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BodegroMailLibary
{
    public class SentMail
    {
        public void NewMail()
        {
            private static string clientId = "your-app-client-id";
            private static string tenantId = "your-tenant-id";
            private static string clientSecret = "your-client-secret"; // If using client credentials

            public static async Task Main(string[] args)
            {
                var confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithTenantId(tenantId)
                    .WithClientSecret(clientSecret)
                    .Build();

                var scopes = new[] { "https://graph.microsoft.com/.default" };

                var authResult = await confidentialClientApplication
                    .AcquireTokenForClient(scopes)
                    .ExecuteAsync();

                var token = authResult.AccessToken;
                var graphClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider((requestMessage) =>
                    {
                        requestMessage
                            .Headers
                            .Authorization = new AuthenticationHeaderValue("Bearer", token);

                        return Task.CompletedTask;
                    })
                );

                await SendEmail(graphClient);
            }

            private static async Task SendEmail(GraphServiceClient graphClient)
            {
                var message = new Message
                {
                    Subject = "Testing email subject",
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = "Here you will put your email message"
                    },
                    ToRecipients = new List<Recipient>()
            {
                new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = "recipient_email@domain.com"
                    }
                }
            }
                };

                await graphClient.Me.SendMail(message, null).Request().PostAsync();
                Console.WriteLine("Email sent successfully!");
        }
    }
    }
}
