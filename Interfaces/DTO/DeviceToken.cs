
using DomainModel;

namespace Interfaces.DTO
{
    public class DeviceTokenDTO
    {
        public int id { get; set; }

        public string token { get; set; }

        public DeviceTokenDTO(DeviceToken deviceToken)
        {
            id = deviceToken.Id;
            token = deviceToken.Token;
        }
    }
}
