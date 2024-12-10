//using BLL.Services;
//using Interfaces.DTO;
//using Interfaces.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Hosting.Internal;

//namespace Endpoints.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NotificationController: Controller
//    {
//        private readonly INotificationService _notificationService;

//        public NotificationController(INotificationService notificationService)
//        {
//            _notificationService = notificationService;
//        }

//        // GET: api/<CarsController>
//        [HttpPost(nameof(PushNotification))]
//        public async Task<ActionResult> PushNotification()
//        {
//            try
//            {
//               await _notificationService.GenerateFCM_Auth_SendNotifcn();
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return Problem(ex.Message);
//            }
//        }
//    }
//}
