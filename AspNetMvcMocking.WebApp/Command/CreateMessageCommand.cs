using System;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.Command
{
    public interface ICreateMessageCommand
    {
        Int64 Execute(String text, Int32 userSenderId, Int32 userRecipientId);
    }

    public class CreateMessageCommand : ICreateMessageCommand
    {
        private readonly IMessagesRepository messagesRepository;

        public CreateMessageCommand(IMessagesRepository messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public Int64 Execute(String text, Int32 userSenderId, Int32 userRecipientId)
        {
            return messagesRepository.CreateMessage(new Message
                {
                    Text = text,
                    UserSenderId = userSenderId,
                    UserRecipientId = userRecipientId,
                    MessageDate = DateTime.Now
                });
        } 
    }
}