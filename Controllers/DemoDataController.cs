using asp_net_assignment.Interfaces;
using asp_net_assignment.Models.Data;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _dataService.AddDataAsync(dto, userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllData()
        {
            var dataList = await _dataService.GetAllDataAsync();

            var result = dataList.Select(d => new
            {
                d.Id,
                d.Text,
                d.UserId
            });

            return Ok(result);
        }
    }
}
