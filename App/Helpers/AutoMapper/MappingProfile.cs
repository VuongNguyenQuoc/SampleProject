using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Tenant, TenantDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Order,OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
