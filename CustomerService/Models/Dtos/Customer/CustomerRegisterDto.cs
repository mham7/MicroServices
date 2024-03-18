namespace CustomerService.Models.Dtos.Customer
{
    public class CustomerRegisterDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string password { get; set; } = null!;

        public int? Phone { get; set; }

    }
}
