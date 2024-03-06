using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;
using ProductService.Model.Dto.Size;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : SuperController<Size, AddSizeDto>
    {
        public SizeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
