namespace asp_net_assignment.Models.DTO.Auth
{
    public class AuthResultDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
