using AutoMapper;
using Project_01.DTO.Product;
using Project_01.Models;

namespace Project_01.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName));
        
        CreateMap<ProductRequest, Product>()
            .ForMember(dest => dest.Type, opt => opt.Ignore());
    }
}