namespace CustomerService.Interfaces.Business_Logic.Utilities
{
    public interface IEmailSenderService
    {
        public string SendOTPMail(string otp, string email,string name);
    }
}
