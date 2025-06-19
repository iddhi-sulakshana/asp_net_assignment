using asp_net_assignment.Interfaces;
using asp_net_assignment.Models.Data;
using asp_net_assignment.Models.DTO;
using asp_net_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp_net_assignment.Services
{
    public class DemoDataService : IDemoDataService
    {
        private readonly ApplicationDbContext _context;

        public DemoDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddDataAsync(DemoDataDTO dto, string userId)
        {
            var data = new DemoData
            {
                Text = dto.Text,
                UserId = userId
            };

            _context.RandomData.Add(data);
            await _context.SaveChangesAsync();

            return "Data saved";
        }

        public async Task<List<DemoData>> GetAllDataAsync()
        {
            return await _context.RandomData.ToListAsync();
        }
    }
}
