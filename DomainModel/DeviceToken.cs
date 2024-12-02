
namespace DomainModel
{
    public class DeviceToken
    {
        public int Id { get; set; }

        public string Token { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
