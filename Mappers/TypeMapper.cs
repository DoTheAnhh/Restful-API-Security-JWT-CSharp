using AutoMapper;
using Project_01.DTO.Type;

namespace Project_01.Mappers;

public class TypeMapper : Profile
{
    public TypeMapper()
    {
        CreateMap<Type, TypeResponse>();

        CreateMap<TypeRequest, Type>();
    }
}