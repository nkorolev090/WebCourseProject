namespace Interfaces.DTO
{
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

    public class NotificationRoot
    {

        public Message message
        {
            get;
            set;
        }

    }
}
