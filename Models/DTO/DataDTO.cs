using System.ComponentModel.DataAnnotations;

namespace asp_net_assignment.Models.DTO
{
    public class DemoDataDTO
    {
        [Required(ErrorMessage = "Text is required")]
        public string? Text { get; set; }
    }
}
