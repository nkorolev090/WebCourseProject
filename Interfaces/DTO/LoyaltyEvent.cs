namespace Interfaces.DTO
{
    public partial class LoyaltyEventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int DiscountPoints { get; set; }
        public string ImageURL { get; set; } = null!;
    }
}
