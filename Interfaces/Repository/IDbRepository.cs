using DomainModel;

namespace Interfaces.Repository
{
    public interface IDbRepository
    {
        IRepository<Client> Clients {  get; }
        IRepository<Car> Cars { get; }
        IRepository<Slot> Slots { get; }
        IRepository<Registration> Registrations { get; }
        IRepository<Breakdown> Breakdowns { get; }
        IRepository<Mechanic> Mechanics { get; }
        IRepository<MechanicBreakdown> Mechanic_Breakdowns {  get; }
        IRepository<Status> Statuses { get; }
        IRepository<Discount> Discouts {  get; }
        IRepository<LoyaltyEvent> LoyaltyEvents { get; }
        IRepository<Cart> Carts { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<Promocode> Promocodes { get; }
        Task<int> SaveAsync();
    }
}
