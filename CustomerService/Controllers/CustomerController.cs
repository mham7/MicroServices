using AutoMapper;
using CustomerService.Features.Generic.Command.CreateCommand;
using CustomerService.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : SuperController<Customer, Customer, Customer>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<Customer> Post([FromForm] Customer dto)
        {
            return await _mediator.Send(new CreateCommand<Customer>(dto));
        }
    }
}
