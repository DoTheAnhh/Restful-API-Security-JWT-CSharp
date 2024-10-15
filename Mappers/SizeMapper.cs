using AutoMapper;
using Project_01.DTO.Size;
using Project_01.Models;

namespace Project_01.Mappers;

public class SizeMapper : Profile
{
    public SizeMapper()
    {
        CreateMap<Size, SizeResponse>();

        CreateMap<SizeRequest, Size>();
    }
}