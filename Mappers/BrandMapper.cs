using AutoMapper;
using Project_01.DTO.Brand;
using Project_01.Models;

namespace Project_01.Mappers;

public class BrandMapper : Profile
{
    public BrandMapper()
    {
        CreateMap<Brand, BrandResponse>();

        CreateMap<BrandRequest, Brand>();
    }
}