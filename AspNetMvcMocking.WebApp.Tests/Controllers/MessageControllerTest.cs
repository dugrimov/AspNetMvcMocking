using System;
using System.Globalization;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnityAutoMoq;
using AspNetMvcMocking.WebApp.Command;
using AspNetMvcMocking.WebApp.Controllers;
using AspNetMvcMocking.WebApp.Models;

namespace AspNetMvcMocking.WebApp.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTest
    {
        private Mock<ICreateMessageCommand> createMessageCommandMock;
        private Mock<IGetNewestMessagesCommand> getNewestMessagesCommandMock;
        private MessageController controller;

        [TestInitialize]
        public void Init()
        {
            // This container will initialize dependencies with mocks
            var container = new UnityAutoMoqContainer();
            // Get controller with mocked dependencies
            controller = container.Resolve<MessageController>();
            // Get mocks which the controller use
            createMessageCommandMock = container.GetMock<ICreateMessageCommand>();
            getNewestMessagesCommandMock = container.GetMock<IGetNewestMessagesCommand>();
        }

        [TestMethod]
        public void TestCreateMessage()
        {
            // Initialize source data
            var message = new MessageModel {Text = "Привет!", UserSenderId = 1, UserRecipientId = 2};
            const long messageId = 999L;
            // Setup mock for createMessageCommand
            createMessageCommandMock.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                                    .Returns(messageId)
                                    .Verifiable();
            // Call controller action
            var result = controller.CreateMessage(message) as ContentResult;
            // Check action result
            Assert.IsNotNull(result);
            Assert.AreEqual(messageId.ToString(CultureInfo.InvariantCulture), result.Content);
            // Check that controller calls command with correct arguments
            createMessageCommandMock.Verify(c => c.Execute(message.Text, message.UserSenderId, message.UserRecipientId));
        }

        [TestMethod]
        public void TestNewMessages()
        {
            // Initialize source data
            const int userId = 111;
            var message1 = new MessageModel {Text = "текст 1", UserRecipientId = userId, UserSenderId = 222};
            var message2 = new MessageModel {Text = "текст 2", UserRecipientId = userId, UserSenderId = 333};
            // Setup mock for getNewestMessagesCommand
            getNewestMessagesCommandMock.Setup(c => c.Execute(userId))
                .Returns(new[] {message1, message2})
                .Verifiable(); // Plans verification at the end of the test
            // Call controller action
            var result = controller.NewMessages(userId) as JsonResult;
            Assert.IsNotNull(result);
            // The actual messages are obtained by typecasting
            var actualMessages = result.Data as MessageModel[];
            // Check response content
            Assert.AreEqual(2, actualMessages.Length);
            Assert.AreEqual(message1.Text, actualMessages[0].Text);
            Assert.AreEqual(message1.UserSenderId, actualMessages[0].UserSenderId);
            Assert.AreEqual(message1.UserRecipientId, actualMessages[0].UserRecipientId);
            Assert.AreEqual(message2.Text, actualMessages[1].Text);
            Assert.AreEqual(message2.UserSenderId, actualMessages[1].UserSenderId);
            Assert.AreEqual(message2.UserRecipientId, actualMessages[1].UserRecipientId);
            // Check that command calls getNewestMessagesCommand with expected arguments
            getNewestMessagesCommandMock.Verify();
        }
    }
}