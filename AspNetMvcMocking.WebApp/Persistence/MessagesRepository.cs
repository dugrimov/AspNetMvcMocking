using System;

namespace AspNetMvcMocking.WebApp.Persistence
{
    public interface IMessagesRepository
    {
        Int64 CreateMessage(Message message);
    }

    public class MessagesRepository : IMessagesRepository
    {
        public Int64 CreateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}