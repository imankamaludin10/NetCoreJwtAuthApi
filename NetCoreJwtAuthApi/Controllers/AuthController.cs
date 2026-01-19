using NetCoreJwtAuthApi.DTOs;
using NetCoreJwtAuthApi.Models;
using NetCoreJwtAuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreJwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var token = _authService.Login(dto);
            return Ok(new { token });
        }
    }
}
