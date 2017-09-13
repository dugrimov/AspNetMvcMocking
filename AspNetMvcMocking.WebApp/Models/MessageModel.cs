using System;

namespace AspNetMvcMocking.WebApp.Models
{
    public class MessageModel
    {
        public string Text { get; set; }
        public Int32 UserSenderId { get; set; }
        public Int32 UserRecipientId { get; set; }
    }
}