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
        public BreakdownDTO GetBreakdown(int id)
        {
            return new BreakdownDTO(db.Breakdowns.GetItem(id));
        }

        public List<BreakdownDTO> GetAllBreakdowns()
        {
            return db.Breakdowns.GetList().Select(i => new BreakdownDTO(i)).ToList();
        }
    }
}
