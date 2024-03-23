using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBreakdownService
    {
        List<BreakdownDTO> GetAllBreakdowns();

        BreakdownDTO GetBreakdown(int id);
    }
}
