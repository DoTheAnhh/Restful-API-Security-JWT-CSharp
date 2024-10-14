using AutoMapper;
using Project_01.DTO.User;
using Project_01.Models;

namespace Project_01.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)) // Ánh xạ UserName
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)) // Ánh xạ Email
            .ForMember(dest => dest.Token, opt => opt.Ignore()); // Bỏ qua Token trong ánh xạ này

        CreateMap<LoginRequest, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Bỏ qua PasswordHash
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)); // Ánh xạ Email

        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Bỏ qua PasswordHash
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)) // Ánh xạ Email
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)); // Ánh xạ UserName
    }
}