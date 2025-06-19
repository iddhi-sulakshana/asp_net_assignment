using asp_net_assignment.Interfaces;
using asp_net_assignment.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_assignment.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok("Registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null) return Unauthorized();
            Response.Headers.Append("Authorization", $"Bearer {token}");
            return Ok();
        }
    }
}