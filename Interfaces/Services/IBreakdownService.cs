using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface IBreakdownService
    {
        Task<List<BreakdownDTO>> GetAllBreakdownsAsync();
        Task<List<BreakdownDTO>> GetBreakdownsByQueryAsync(string query);

        Task<BreakdownDTO> GetBreakdownAsync(int id);
    }
}
