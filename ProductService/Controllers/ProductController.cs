using AutoMapper;
using Azure.Storage.Blobs.Models;
using Contracts;
using Contracts.ProductEvents;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Features.Generic.Command.DeleteCommand;
using ProductService.Features.Generic.Query.GetCommand;
using ProductService.Features.Product.Command.CreateProduct;
using ProductService.Features.Product.Command.DeletProduct;
using ProductService.Features.Product.Command.UpdateProduct;
using ProductService.Interfaces.Services;
using ProductService.Interfaces.Services.Utilities;
using ProductService.Model;
using ProductService.Model.Dto.Product;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : SuperController<Productt,AddProductDto>
    {
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProductController(IMediator mediator, IMapper mapper,IPublishEndpoint publishEndpoint) : base(mediator, mapper)
        {
            _mapper = mapper;
            _mediator=mediator;
            _publishEndpoint = publishEndpoint;
        }

       

        [HttpPost("Add")]
        public override async Task<Productt> Post([FromForm]AddProductDto dto)
        {

           ProductDto pdto=_mapper.Map<ProductDto>(dto);
            return await _mediator.Send(new CreateProductCommand(dto));
             
        }

        [HttpPut("Update")]

        public override async Task<Productt> Put(Productt p)
        {
            return await _mediator.Send(new UpdateProductCommand(p));
        }


        [HttpPost("Increment")]
        public async Task Post(ProductUpdatedEvent a)
        {

            await _publishEndpoint.Publish<ProductUpdatedEvent>(a);
        }
        [HttpDelete("{id}")]
        public override async Task<Productt> Delete(int id)
        {

            Productt entity = await _mediator.Send(new GetCommand<Productt>(id));
            return await _mediator.Send(new DeleteProductCommand(entity));

        }

    }
}
