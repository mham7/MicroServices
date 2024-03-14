using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Features.Generic.Command.CreateCommand;
using CustomerService.Features.Generic.Command.DeleteCommand;
using CustomerService.Features.Generic.Command.UpdateCommand;
using CustomerService.Features.Generic.Query.GetAllCommand;
using CustomerService.Features.Generic.Query.GetCommand;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperController<T> : ControllerBase where T : class 
    {
        private readonly IMediator _mediator;
       

        public SuperController(IMediator mediator)
        {
            _mediator=mediator;
          
        }

        [HttpGet]
        public virtual async Task<List<T>> Get()
        {

            return await _mediator.Send(new GetAllGenericCommand<T>());
        }


        [HttpGet("{id}")]
        public virtual async Task<T> Get(int id)
        {
            return await _mediator.Send(new GetCommand<T>(id));
        }


        [HttpPost]
        public virtual async Task<T> Post([FromBody] T entity)
        {
           
            return await _mediator.Send(new CreateCommand<T>(entity));
        }


        [HttpPut("Update")]
        public virtual async Task<T> Put([FromBody] T entity)
        {
            return await _mediator.Send(new UpdateCommand<T>(entity));

        }


        [HttpDelete("{id}")]
        public virtual async Task<T> Delete(int id)
        {
            T entity = await _mediator.Send(new GetCommand<T>(id));
            return await _mediator.Send(new DeleteCommand<T>(entity));

        }
    }
}
