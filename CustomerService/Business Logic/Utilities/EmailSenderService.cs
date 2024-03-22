using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using CustomerService.Interfaces.Business_Logic.Utilities;
using CustomerService.Common.Messages.Email_Messages;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Amazon;
namespace CustomerService.Services.Utilities
{
    public class EmailSenderService
    {
        public string SendOTPMail(string otp, string email, string name)
        {
            string fromEmail = "m.hammadcr7777@outlook.com"; // Replace with verified SES email address
            string toEmail = email;
            string subject = "Test Email from .NET with SES";
            string body = "This is a test email sent using AWS SES and .NET.";
          
            using (var client = new AmazonSimpleEmailServiceClient("AKIAV7GTMXMY3OYMPK72", "BNE+HWcYdmS3fNpw0QNSp6rjza5/mwNaTK84nrF/EPjd", RegionEndpoint.APNortheast2))
            {
                var message = new Amazon.SimpleEmail.Model.SendEmailRequest
                {
                    Destination = new Amazon.SimpleEmail.Model.Destination
                    {
                        ToAddresses = new List<string> { toEmail }
                    },
                    Source = fromEmail,
                    Message = new Message
                    {
                        Body = new Amazon.SimpleEmail.Model.Body
                        {
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = body
                            }
                        },
                        Subject = new Content
                        {
                            Charset = "UTF-8",
                            Data = subject
                        }
                    }
                };

                client.SendEmailAsync(message);
            
            }
   
            //using (MailMessage mail = new MailMessage())
            //{
            //    mail.From = new MailAddress("m.hammadcr7777@gmail.com");
            //    mail.To.Add(email);
            //    mail.Subject = EmailMessages.OtpSubjectTemplate;
            //    mail.Body = EmailMessages.GetOtpMessage(name, otp);
            //    mail.IsBodyHtml = true;


            //    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp-relay.brevo.com", 587))
            //    {

            //        smtp.Credentials = new NetworkCredential("m.hammadcr7777@gmail.com", "qWRXpJfyknbvIOxw");
            //        smtp.EnableSsl = true;
            //        smtp.Send(mail);

            //    }
            //}

            //var client = new SmtpClient("live.smtp.mailtrap.io", 587)
            //{
            //    Credentials = new NetworkCredential("api", "c31f3c383b60b7c35a115fa64335c025"),
            //    EnableSsl = true
            //};
            //string EmailMessage = EmailMessages.GetOtpMessage(name, otp);

            //    client.Send("mailtrap@demomailtrap.com", email, EmailMessages.OtpSubjectTemplate, EmailMessage);

            return "ok";

        
        }
    }
}
