using System.ComponentModel.DataAnnotations;

namespace asp_net_assignment.Models.DTO.Auth
{
    public class LoginDTO
    {

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
