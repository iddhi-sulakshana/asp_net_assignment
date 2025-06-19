using asp_net_assignment.Models.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace asp_net_assignment.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDTO dto);
        Task<AuthResultDto> LoginAsync(LoginDTO dto);
    }
}
