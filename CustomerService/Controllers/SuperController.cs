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
    public class SuperController<T, X,Y> : ControllerBase where T : class where X : class where Y: class
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SuperController(IMediator mediator, IMapper mapper)
        {
            _mediator=mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<List<T>> Get()
        {
            return await _mediator.Send(new GetAllCommand<T>());
        }


        [HttpGet("{id}")]
        public virtual async Task<T> Get(int id)
        {
            return await _mediator.Send(new GetCommand<T>(id));
        }


        [HttpPost]
        public virtual async Task<T> Post([FromBody] X entity)
        {
            T mappedEntity = _mapper.Map<T>(entity);
            return await _mediator.Send(new CreateCommand<T>(mappedEntity));
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
