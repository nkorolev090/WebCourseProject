using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface INotificationService
    {
        //Task GenerateFCM_Auth_SendNotifcn();
        Task<Boolean> SendNotification(NotificationRoot notificationRoot);
    }
}
