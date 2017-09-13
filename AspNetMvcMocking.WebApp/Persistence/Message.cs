using System;

namespace AspNetMvcMocking.WebApp.Persistence
{
    public class Message
    {
        public Int64 Id { get; set; }
        public string Text { get; set; }
        public Int32 UserSenderId { get; set; }
        public Int32 UserRecipientId { get; set; }
        public DateTime MessageDate { get; set; }
    }
}