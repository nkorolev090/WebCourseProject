using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
