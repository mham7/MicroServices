using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;
using ProductService.Model.Dto.Colour;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : SuperController<Colour, AddColourDto>
    {
        public ColourController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
