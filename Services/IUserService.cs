using Project_01.DTO.User;
using Project_01.Models;

namespace Project_01.Services;

public interface IUserService
{
    Task<bool> RegisterAsync(RegisterRequest registerRequest);
    
    Task<UserResponse> LoginAsync(LoginRequest loginRequest);
}