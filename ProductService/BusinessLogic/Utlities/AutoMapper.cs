using AutoMapper;
using Contracts.ProductEvents;
using MassTransit;
using ProductService.Model;
using ProductService.Model.Dto.Product;
using System.Data;
using System.Threading.Tasks;

namespace ProductService.Service.Utlities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Productt, ProductDto>();
            CreateMap<ProductDto, Productt>();
            CreateMap<AddProductDto,ProductDto>();
            CreateMap<ProductDto, AddProductDto>();
            CreateMap<ProductDto, ProductCreatedEvent>();
            CreateMap<ProductCreatedEvent, ProductDto>();
            CreateMap<Productt, ProductCreatedEvent>();
            CreateMap<ProductCreatedEvent, Productt>();
        }
    }
}
