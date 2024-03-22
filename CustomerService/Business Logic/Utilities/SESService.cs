using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using AutoMapper.Internal;
using CustomerService.Interfaces.Business_Logic.Utilities;
using Microsoft.Extensions.Options;
using CustomerService.Common.Messages.Email_Messages;

namespace CustomerService.Business_Logic.Utilities
{
    public class SESService : IEmailSenderService
    {
        private readonly IAmazonSimpleEmailService _mailService;
        public SESService(
            IAmazonSimpleEmailService mailService)
        {
            
            _mailService = mailService;
        }
      

       public async Task<string> SendOTPMail(string otp, string email, string name)
        {

            var messageId = "";
            try
            {
                var response = await _mailService.SendEmailAsync(
                    new SendEmailRequest
                    {
                        Destination = new Destination
                        {
                            ToAddresses = new List<string> { email }
                        },
                        Message = new Message
                        {
                            Body = new Body
                            {
                                Html = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = "HI"
                                },
                                Text = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = "HI"
                                }
                            },
                            Subject = new Content
                            {
                                Charset = "UTF-8",
                                Data = "Welcome"
                            }
                        },
                        Source = "m.hammadcr77777@gmail.com"
                    }) ;

                messageId = response.MessageId;

            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"AmazonServiceException occurred: {ex.Message}");

                // Check if there's more specific information
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            return messageId;
        }
            //return messageId;
            //try
            //{
            //    string body = EmailMessages.GetOtpMessage(name, otp);

            //    var mailBody = new Body(new Content(body));
            //    var message = new Message(new Content(EmailMessages.OtpSubjectTemplate), mailBody);
            //    var destination = new Destination(new List<string> { email! });
            //    var request = new SendEmailRequest("m.hammadcr7777@gmail.com", destination, message);
            //    await _mailService.SendEmailAsync(request);
            //    return "ok";
            //}
            //catch(Exception ex)
            //{
            //    throw;
            //}
        }
    }

