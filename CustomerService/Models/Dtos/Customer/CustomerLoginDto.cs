using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models.Dtos.Customer
{
    public class CustomerLoginDto
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;
    }
}
