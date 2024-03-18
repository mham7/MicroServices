using MediatR;
using CustomerService.Models;
using CustomerService.Models.Dtos.Customer;

namespace CustomerService.Features.Customer.Command.CreateCustomer
{
    public class CreateCustomer : IRequest<CustomerService.Models.Customer>
    {
        public CreateCustomer(CustomerRegisterDto dto)
        {
            _dto = dto;
        }

        public CustomerRegisterDto _dto { get; set; }
    }
}
