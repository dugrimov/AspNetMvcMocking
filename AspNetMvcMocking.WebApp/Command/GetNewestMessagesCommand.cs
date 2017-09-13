using System;
using System.Collections.Generic;
using System.Linq;
using AspNetMvcMocking.WebApp.Models;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.Command
{
    public interface IGetNewestMessagesCommand
    {
        IEnumerable<MessageModel> Execute(Int32 userId);
    }

    public class GetNewestMessagesCommand : IGetNewestMessagesCommand
    {
        private readonly IUserRepository userRepository;
        private readonly IMessagesView messagesView;

        public GetNewestMessagesCommand(IUserRepository userRepository, IMessagesView messagesView)
        {
            this.userRepository = userRepository;
            this.messagesView = messagesView;
        }

        public IEnumerable<MessageModel> Execute(Int32 userId)
        {
            var dbMessages = messagesView.GetMessages(userId).ToList();
            var userMessages = dbMessages.Select(message => new MessageModel
                {
                    Text = message.Text,
                    UserSenderId = message.UserSenderId,
                    UserRecipientId = message.UserRecipientId
                });
            userRepository.SetLastViewedMessageId(userId, dbMessages.Last().Id);
            return userMessages;
        }
    }
}