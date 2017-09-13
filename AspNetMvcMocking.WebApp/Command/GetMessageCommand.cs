using System;
using AspNetMvcMocking.WebApp.Models;

namespace AspNetMvcMocking.WebApp.Command
{
    public interface IGetMessageCommand
    {
        MessageModel Execute(Int64 messageId);
    }

    public class GetMessageCommand : IGetMessageCommand
    {
        public MessageModel Execute(Int64 messageId)
        {
            throw new NotImplementedException();
        }
    }
}