using CustomerService.Interfaces.Business_Logic.Utilities;
using Org.BouncyCastle.Security;

namespace CustomerService.Services
{
    public class OtpService:IOTPService
    {
        private Dictionary<string, string> Cache = new Dictionary<string, string>();
        private readonly IEmailSenderService _emailSender;
        private readonly ILogger<OtpService> _logger;
        public OtpService(IEmailSenderService emailSender, ILogger<OtpService> logger)
        {
            _emailSender=emailSender;
            _logger=logger;
        }
       
        public string GenerateOTP(string email,string name)
        {
            const int otpLength = 6; 
            var random = new SecureRandom();
            var OTP = random.Next((int)Math.Pow(10, otpLength - 1), (int)Math.Pow(10, otpLength) - 1);
            Cache.Add(email, OTP.ToString());
            _emailSender.SendOTPMail(OTP.ToString(),email,name);
            var timer = new Timer(_ => RemoveOtp(email), null, TimeSpan.FromMinutes(1), Timeout.InfiniteTimeSpan);
            return OTP.ToString();
        }
        private void RemoveOtp(string email)
        {
            _logger.LogInformation($"Removing OTP for email: {email}, OTP value: {Cache[email]}");
            Cache.Remove(email);
        }


    }
}
