using asp_net_assignment.Interfaces;
using asp_net_assignment.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_net_assignment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DemoDataController : Controller
    {
        private readonly IDemoDataService _dataService;

        public DemoDataController(IDemoDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public async Task<IActionResult> AddData(DemoDataDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid data", errors = ModelState });

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _dataService.AddDataAsync(dto, userId);

                return Ok(new { message = "Saved successfully", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while saving data.", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllData()
        {
            try
            {
                var dataList = await _dataService.GetAllDataAsync();

                if (dataList == null || !dataList.Any())
                    return Ok(new { message = "No data found", data = new List<object>() });

                var result = dataList.Select(d => new
                {
                    d.Id,
                    d.Text,
                    d.UserId
                });

                return Ok(new { message = "Data available", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving data.", error = ex.Message });
            }
        }
    }
}
