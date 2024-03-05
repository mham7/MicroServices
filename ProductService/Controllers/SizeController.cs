using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : SuperController<Size, Size>
    {
        public SizeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
