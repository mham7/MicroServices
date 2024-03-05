
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : SuperController<Category, Category>
    {
        public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
