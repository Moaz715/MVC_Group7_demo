using Microsoft.EntityFrameworkCore.Query.Internal;
using MVC_Group7_demo_BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fmail = "moaz88863@gmail.com";
            var fpass = "evnu hphg fbcf ytbo";

            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fmail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = true;

            var smptClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fmail, fpass),
                Port = 587
            };


            await smptClient.SendMailAsync(theMsg);



        }
    }
}
