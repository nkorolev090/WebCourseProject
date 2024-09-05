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
    public class LoyaltyEventService : ILoyaltyEventService
    {
        IDbRepository db;
        public LoyaltyEventService(IDbRepository db) { this.db = db; }
        public async Task<List<LoyaltyEventDTO>> GetAllLoyaltyEventsAsync()
        {
            var events = await db.LoyaltyEvents.GetListAsync();
            return events.Select(e => ToLoyaltyEventDTO(e)).ToList();
        }

        public LoyaltyEventDTO ToLoyaltyEventDTO(LoyaltyEvent loyaltyEvent)
        {
            var dto = new LoyaltyEventDTO() { 
            Id = loyaltyEvent.Id,
            Title = loyaltyEvent.Title,
            ImageURL = loyaltyEvent.ImageURL,
            DiscountPoints = loyaltyEvent.DiscountPoints,
            };

            return dto;
        }
    }
}
