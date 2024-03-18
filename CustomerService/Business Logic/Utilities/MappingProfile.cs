using AutoMapper;
using CustomerService.Models;
using CustomerService.Models.Dtos.Customer;

namespace CustomerService.Business_Logic.Utilities
{
    
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CustomerRegisterDto, Customer>();
                CreateMap<Customer, CustomerRegisterDto>();
        }
        }
    }

