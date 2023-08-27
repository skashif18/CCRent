using CoreBusiness;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class EmailServiceRepository : IEmailServiceRepository
    {
        public async Task<bool> SentEmail(SentEmailModel emailModel)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Mahad Job", "noreply@mahadjobs.com"));
            email.To.Add(new MailboxAddress(emailModel.Email, emailModel.Email));

            email.Subject = emailModel.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailModel.Body
            };
            email.Priority = MessagePriority.Urgent;
            email.XPriority = XMessagePriority.Highest;
            email.Importance = MessageImportance.High;

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync("smtp.gmail.com", 465, true);
                    //smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: only needed if the SMTP server requires authentication
                    await smtp.AuthenticateAsync("noreply@mahadjobs.com", "Noreply@Mahad@123");
                    await smtp.SendAsync(email);
                    //Thread.Sleep(2000);
                    //await smtp.DisconnectAsync(false);
                    smtp.Disconnect(true);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
