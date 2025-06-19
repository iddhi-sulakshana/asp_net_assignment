using asp_net_assignment.Models.Data;
using asp_net_assignment.Models.Entities;

namespace asp_net_assignment.Interfaces
{
    public interface IDemoDataService
    {
        Task<string> AddDataAsync(DemoDataDTO dto, string userId);
        Task<List<DemoData>> GetAllDataAsync();
    }
}
