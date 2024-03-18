using AutoMapper;
using CustomerService.Interfaces.Business_Logic.Utilities;
using CustomerService.Interfaces.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Command.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, CustomerService.Models.Customer>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<CustomerService.Models.Customer> _gen;
        private readonly IOTPService _otpService;
        public CreateCustomerHandler(IGenericRepository<CustomerService.Models.Customer> gen
            ,IOTPService oTPService,IMapper mapper)
        {
            _gen= gen;
            _otpService= oTPService;
            _mapper = mapper;
            
        }
        public async Task<Models.Customer> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
          CustomerService.Models.Customer customer = _mapper.Map<CustomerService.Models.Customer>(request._dto);
         _otpService.GenerateOTP(customer.Email, customer.FirstName);
            //return  await _gen.Post(customer);
            return customer;
        }
    }
}
