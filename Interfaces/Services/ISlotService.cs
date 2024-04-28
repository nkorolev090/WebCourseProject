using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ISlotService
    {
        Task<SlotDTO> CreateSlotAsync(SlotDTO slot);
        Task<List<SlotDTO>> GetAllSlotsAsync();
        Task<List<SlotDTO>> GetSlotsByDate_BreakdownAsync(DateTime startDate, int breakdown_id);
        Task<List<SlotDTO>> GetRegistrationSlotsAsync(int regId);
        Task<Dictionary<string, int>> GetCarSlotsReportAsync(int carId);
        Task<Dictionary<string, int>> GetMechanicSlotsReportAsync(int mechanicId, string mounths);
        Task UpdateSlotAsync(SlotDTO slot);
        Task<SlotDTO> GetSlotAsync(int id);
    }
}
