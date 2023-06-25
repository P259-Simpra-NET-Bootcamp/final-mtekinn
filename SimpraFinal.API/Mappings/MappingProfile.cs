using AutoMapper;
using SimpraFinal.API.DTOs;
using SimpraFinal.Data.Entities;

namespace SimpraFinal.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Coupon, CouponDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<ProductCategoryMap, ProductCategoryMapDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<RegisterDTO, User>().ReverseMap();
    }
}