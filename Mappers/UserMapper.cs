using AutoMapper;
using Project_01.DTO.User;
using Project_01.Models;

namespace Project_01.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserResponse>();

        CreateMap<LoginRequest, User>();
        
        CreateMap<RegisterRequest, User>();   
    }
}