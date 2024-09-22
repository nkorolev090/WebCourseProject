using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;

namespace BLL.Services
{
    public class BreakdownService : IBreakdownService
    {
        IDbRepository db;
        public BreakdownService(IDbRepository db) { this.db = db; }
        public async Task<BreakdownDTO>  GetBreakdownAsync(int id)
        {
            Breakdown breakdown = await db.Breakdowns.GetItemAsync(id);
            return new BreakdownDTO(breakdown);
        }

        public async Task<List<BreakdownDTO>> GetAllBreakdownsAsync()
        {
            List<Breakdown> breakdowns = await db.Breakdowns.GetListAsync();
            return breakdowns.Select(i => new BreakdownDTO(i)).ToList();
        }
        public async Task<List<BreakdownDTO>> GetBreakdownsByQueryAsync(string query)
        {
            List<Breakdown> breakdowns = await db.Breakdowns.GetListAsync();
            return breakdowns.Where(b => b.Title.Contains(query)).Select(i => new BreakdownDTO(i)).ToList();
        }
    }
}
