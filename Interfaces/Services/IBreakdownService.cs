﻿using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBreakdownService
    {
        Task<List<BreakdownDTO>> GetAllBreakdownsAsync();

        Task<BreakdownDTO> GetBreakdownAsync(int id);
    }
}
