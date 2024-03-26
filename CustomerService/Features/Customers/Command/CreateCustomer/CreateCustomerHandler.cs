using AutoMapper;
using CustomerService.Interfaces.Business_Logic.Utilities;
using CustomerService.Interfaces.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Command.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, CustomerService.Models.Users>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<CustomerService.Models.Users> _gen;
        private readonly IOTPService _otpService;
        public CreateCustomerHandler(IGenericRepository<CustomerService.Models.Users> gen
            ,IOTPService oTPService,IMapper mapper)
        {
            _gen= gen;
            _otpService= oTPService;
            _mapper = mapper;
            
        }
        public async Task<Models.Users> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
          CustomerService.Models.Users customer = _mapper.Map<CustomerService.Models.Users>(request._dto);
         //_otpService.GenerateOTP(customer.Email, customer.FirstName);
            //return customer;
            return await _gen.Post(customer);

        }
    }
}
