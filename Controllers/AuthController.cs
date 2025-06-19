using asp_net_assignment.Interfaces;
using asp_net_assignment.Models.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid data", errors = ModelState });

            try
            {
                var result = await _authService.RegisterAsync(dto);
                if (!result.Succeeded)
                    return BadRequest(new { message = "Registration failed", errors = result.Errors });

                return Ok(new { message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during registration", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid data", errors = ModelState });

            try
            {
                var result = await _authService.LoginAsync(dto);

                if (!result.Success)
                    return Unauthorized(new { message = result.Message });

                Response.Headers.Append("Authorization", $"Bearer {result.Token}");
                return Ok(new
                {
                    message = "Login successful"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during login", error = ex.Message });
            }
        }
    }
}