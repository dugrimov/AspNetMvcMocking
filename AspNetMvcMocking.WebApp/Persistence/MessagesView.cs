using System;
using System.Collections.Generic;

namespace AspNetMvcMocking.WebApp.Persistence
{
    public interface IMessagesView
    {
        IEnumerable<Message> GetMessages(Int32 userId);
    }

    public class MessagesView : IMessagesView
    {
        public IEnumerable<Message> GetMessages(int userId)
        {
            throw new NotImplementedException();
        }
    }
}