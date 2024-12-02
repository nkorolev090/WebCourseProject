using Google.Apis.Auth.OAuth2;
using Interfaces.Services;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BLL.Services
{
    public class NotificationService: INotificationService
    {
        public async Task GenerateFCM_Auth_SendNotifcn()

        {
            //----------Generating Bearer token for FCM---------------

            string fileName = "autoservicemobile-d10c4-firebase-adminsdk-webs0-220e953c5a.json"; //Download from Firebase Console ServiceAccount

            string scopes = "https://www.googleapis.com/auth/firebase.messaging";
            var bearertoken = ""; // Bearer Token in this variable
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))

            {

                bearertoken = GoogleCredential
                  .FromStream(stream) // Loads key file
                  .CreateScoped(scopes) // Gathers scopes requested
                  .UnderlyingCredential // Gets the credentials
                  .GetAccessTokenForRequestAsync().Result; // Gets the Access Token

            }

            ///--------Calling FCM-----------------------------

            var clientHandler = new HttpClientHandler();
            var client = new HttpClient(clientHandler);

            client.BaseAddress = new Uri("https://fcm.googleapis.com/v1/projects/autoservicemobile-d10c4/messages:send"); // FCM HttpV1 API

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //client.DefaultRequestHeaders.Accept.Add("Authorization", "Bearer " + bearertoken);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearertoken); // Authorization Token in this variable

            //---------------Assigning Of data To Model --------------

            Root rootObj = new Root();
            rootObj.message = new Message();

            rootObj.message.token = "fkunRRCxTIeyB0SpGo6eqe:APA91bFZlkeFzVKXSIkLET_YgqYgNNY8YpNX9FQv4ggc27leMV0A-WbNN3pYzIw-K9WvWVTfV16MHZ06TUjB02QJHST4j-pNn4y0fL5uymRcC8krFyyGwDU"; //FCM Token id

            //rootObj.message.data = new Data();
            //rootObj.message.data.title = "Data Title";
            //rootObj.message.data.body = "Data Body";
            //rootObj.message.data.key_1 = "Sample Key";
            //rootObj.message.data.key_2 = "Sample Key2";
            rootObj.message.notification = new Notification();
            rootObj.message.notification.title = "From Server";
            rootObj.message.notification.body = "To Pixel Nikita";

            //-------------Convert Model To JSON ----------------------

            var jsonObj = JsonSerializer.Serialize(rootObj);

            //------------------------Calling Of FCM Notify API-------------------

            var data = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://fcm.googleapis.com/v1/projects/autoservicemobile-d10c4/messages:send", data); // Calling The FCM httpv1 API

            //---------- Deserialize Json Response from API ----------------------------------

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);
        }
    }

    public class Data
    {
        public string body
        {
            get;
            set;
        }

        public string title
        {
            get;
            set;
        }

        public string key_1
        {
            get;
            set;
        }

        public string key_2
        {
            get;
            set;
        }

    }

    public class Message
    {

        public string token
        {
            get;
            set;
        }

        public Data data
        {
            get;
            set;
        }

        public Notification notification
        {
            get;
            set;
        }

    }

    public class Notification
    {

        public string title
        {
            get;
            set;
        }

        public string body
        {
            get;
            set;
        }

    }

    public class Root
    {

        public Message message
        {
            get;
            set;
        }

    }
}
