using AutoMapper;
using Project_01.DTO.Product;
using Project_01.Models;
using Type = Project_01.Models.Type;

namespace Project_01.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));

        CreateMap<ProductRequest, Product>();
    }
}