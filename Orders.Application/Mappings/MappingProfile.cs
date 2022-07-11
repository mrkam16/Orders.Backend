using AutoMapper;
using Domain;
using Orders.Application.Orders.Commands.CreateOrder;
using Orders.Application.Orders.Queries;

namespace Orders.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductVm>();                

            CreateMap<Order, GetOrderVm>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(order => order.Products.Sum(p => p.Price * p.Amount)));

            CreateMap<Orders.Commands.CreateOrder.CreateProductVm, Product>()
                .ReverseMap();
        }
    }
}
