using System;

namespace AspNetMvcMocking.WebApp.Persistence
{
    public interface IUserRepository
    {
        Int32 Create(User user);
        void Update(User user);
        void SetLastViewedMessageId(Int32 userId, Int64 messageId);
    }

    public class UserRepository : IUserRepository
    {
        public int Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void SetLastViewedMessageId(int userId, long messageId)
        {
            throw new NotImplementedException();
        }
    }
}