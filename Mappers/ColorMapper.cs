using AutoMapper;
using Project_01.DTO.Color;
using Project_01.Models;

namespace Project_01.Mappers;

public class ColorMapper : Profile
{
    public ColorMapper()
    {
        CreateMap<Color, ColorResponse>();

        CreateMap<ColorRequest, Color>();
    }
}