using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_01.Data;
using Project_01.DTO.User;
using Project_01.Models;
using AutoMapper;

namespace Project_01.Services.impl
{
    public class UserService : IUserService
    {
        private readonly MyDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        private readonly IMapper _mapper;

        public UserService(MyDBContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(RegisterRequest registerRequest)
        {
            // Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await _context.Users
                .SingleOrDefaultAsync(u => u.UserName == registerRequest.UserName || u.Email == registerRequest.Email);
            if (existingUser != null)
            {
                return false; // Người dùng đã tồn tại
            }

            var user = _mapper.Map<User>(registerRequest);
            user.PasswordHash = HashPassword(registerRequest.Password);
            user.Role = "User";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginRequest.Email);
            if (user != null && VerifyPassword(loginRequest.Password, user.PasswordHash))
            {
                var token = GenerateJwtToken(user);
                var userResponse = _mapper.Map<UserResponse>(user);
                userResponse.Token = token; // Thêm token vào UserResponse
                return userResponse;
            }
            return null; // Đăng nhập thất bại
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Đặt claim 'sub'
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // Đặt claim 'email'
                new Claim(ClaimTypes.Role, user.Role), // Đặt claim 'role'
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Thời gian hết hạn
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        private string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(new User(), password);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            Console.WriteLine($"Stored Hash: {storedHash}");
            var result = _passwordHasher.VerifyHashedPassword(null, storedHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
