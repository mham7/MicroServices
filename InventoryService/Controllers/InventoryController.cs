using InventoryService.Features.Query.GetInventoryList;
using InventoryService.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<List<Inventory>> Get()
        {
            return await _mediator.Send(new GetInventoryList());
        }
    }
}
