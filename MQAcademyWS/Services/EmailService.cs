using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MQAcademyWS.Model;
using System.Net;

namespace MQAcademyWS.Services
{
    public class EmailService
    {
        public async Task SendEmail(EmailMessage emailMessage)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtp.PickupDirectoryLocation = @"c:\maildump";
                var message = new MailMessage
                {
                    Body = emailMessage.Body,
                    Subject = emailMessage.Subject,
                    From = new MailAddress(emailMessage.From)
                };
                var credential = new NetworkCredential
                {
                    UserName = "srt8muscle@gmail.com",  // replace with valid value
                    Password = "@39jsf9c21@"  // replace with valid value
                };
                message.To.Add(emailMessage.To);
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
