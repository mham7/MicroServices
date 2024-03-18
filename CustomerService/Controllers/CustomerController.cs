using AutoMapper;
using CustomerService.Features.Generic.Command.CreateCommand;
using CustomerService.Features.Customer.Command.CreateCustomer;
using CustomerService.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Models.Dtos.Customer;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : SuperController<Customer>
    {
      
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) : base(mediator)
        {
           
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<Customer> Register([FromForm] CustomerRegisterDto dto)
        {
            return await _mediator.Send(new CreateCustomer(dto));

        }
        [HttpPost("OTPVerify")]
        public async Task<IActionResult> Get([FromForm] string otp)
        {
            return Ok("top");

        }
    }
}
