using Microsoft.AspNetCore.Mvc;
using Project_01.DTO.User;
using Project_01.Models;
using Project_01.Services;

namespace Project_01.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
    
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.UserName) || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.Password))
            {
                return BadRequest("Thông tin đăng ký không hợp lệ.");
            }

            var result = await _userService.RegisterAsync(registerRequest);
            if (result)
            {
                return Ok("Đăng ký thành công." );
            }
            return BadRequest("Người dùng đã tồn tại.");
        }
    
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Thông tin đăng nhập không hợp lệ.");
            }

            var userResponse = await _userService.LoginAsync(loginRequest);
            if (userResponse != null)
            {
                return Ok(userResponse);
            }
            return BadRequest("Sai tài khoản hoặc mật khẩu");
        }
    }

}