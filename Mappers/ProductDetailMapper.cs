using AutoMapper;
using Project_01.DTO.ProductDetail;
using Project_01.Models;

namespace Project_01.Mappers;

public class ProductDetailMapper : Profile
{
    public ProductDetailMapper()
    {
        CreateMap<ProductDetail, ProductDetailResponse>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.ColorName))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.SizeName))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));

        CreateMap<ProductDetailRequest, ProductDetail>();
    }
}