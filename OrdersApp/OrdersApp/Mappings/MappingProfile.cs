using AutoMapper;
using OrdersApp.Domain.Core.Entities;
using OrdersApp.Dtos;
using OrdersApp.Enums;
using OrdersApp.Helpers;

namespace OrdersApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Status, 
                    opt => opt.MapFrom(
                        src => EnumHelper.GetDescription((OrderStatus)src.Status)));

            CreateMap<ProductInOrder, ProductDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        src => src.Product.Name))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(
                        src => src.Product.Price))
                .ForMember(dest => dest.Quantity,
                    opt => opt.MapFrom(
                        src => src.ProductCount));
        }
    }
}