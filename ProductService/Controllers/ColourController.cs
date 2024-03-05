using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : SuperController<Colour, Colour>
    {
        public ColourController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
