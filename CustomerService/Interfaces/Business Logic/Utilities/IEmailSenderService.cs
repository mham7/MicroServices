namespace CustomerService.Interfaces.Business_Logic.Utilities
{
    public interface IEmailSenderService
    {
        public  Task<string> SendOTPMail(string otp, string email,string name);
    }
}
