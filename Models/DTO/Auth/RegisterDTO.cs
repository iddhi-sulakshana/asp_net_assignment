using System.ComponentModel.DataAnnotations;

namespace asp_net_assignment.Models.DTO.Auth
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string? Password { get; set; }
    }
}
