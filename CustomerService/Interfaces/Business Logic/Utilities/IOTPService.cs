namespace CustomerService.Interfaces.Business_Logic.Utilities
{
    public interface IOTPService
    {
        public string GenerateOTP(string email,string name);
    }
}
