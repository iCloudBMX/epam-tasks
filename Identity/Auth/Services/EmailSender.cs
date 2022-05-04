using Auth.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Auth.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);
            
            await SendAsync(mailMessage);
        }            

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(this.emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(this.emailConfiguration.UserName, this.emailConfiguration.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(this.emailConfiguration.UserName, this.emailConfiguration.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
