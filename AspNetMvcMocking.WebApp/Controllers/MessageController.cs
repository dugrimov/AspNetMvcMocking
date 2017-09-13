using System;
using System.Globalization;
using System.Web.Mvc;
using AspNetMvcMocking.WebApp.Command;
using AspNetMvcMocking.WebApp.Models;

namespace AspNetMvcMocking.WebApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly ICreateMessageCommand createMessageCommand;
        private readonly IGetNewestMessagesCommand getNewestMessagesCommand;

        public MessageController(ICreateMessageCommand createMessageCommand,
                                 IGetNewestMessagesCommand getNewestMessagesCommand)
        {
            this.createMessageCommand = createMessageCommand;
            this.getNewestMessagesCommand = getNewestMessagesCommand;
        }

        [HttpPost]
        public ActionResult CreateMessage(MessageModel message)
        {
            var messageId = createMessageCommand.Execute(message.Text, message.UserSenderId, message.UserRecipientId);
            return Content(messageId.ToString(CultureInfo.InvariantCulture));
        }

        [HttpGet]
        public ActionResult NewMessages(Int32 userId)
        {
            var messages = getNewestMessagesCommand.Execute(userId);
            return Json(messages);
        }

    }
}