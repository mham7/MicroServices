using System.Net.Mail;
using System.Net;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using CustomerService.Interfaces.Business_Logic.Utilities;
using CustomerService.Common.Messages.Email_Messages;
namespace CustomerService.Services.Utilities
{
    public class EmailSenderService:IEmailSenderService
    {
        public string SendOTPMail(string otp,string email,string name)
        {
            
            var client = new SmtpClient("live.smtp.mailtrap.io", 587)
            {
                Credentials = new NetworkCredential("api", "c31f3c383b60b7c35a115fa64335c025"),
                EnableSsl = true
            };
            string EmailMessage = EmailMessages.GetOtpMessage(name, otp);
            
                client.Send("mailtrap@demomailtrap.com", email, EmailMessages.OtpSubjectTemplate, EmailMessage);
                return "OK";
            
           

        }
    }
}
