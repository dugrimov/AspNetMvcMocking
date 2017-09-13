using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AspNetMvcMocking.WebApp.Command;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.Tests.Command
{
    [TestClass]
    public class GetNewestMessagesCommandTest
    {
        [TestMethod]
        public void TestExecute()
        {
            // Creates messages that messagesViewMock returns
            const int userId = 1;
            var message1 = new Message {Text = "text 1", Id = 1L, UserSenderId = 111, UserRecipientId = userId};
            var message2 = new Message {Text = "text 2", Id = 2L, UserSenderId = 333, UserRecipientId = userId};
            // Setup mock for method messagesView.getMessages():
            // if input parameter equals userId, then return messages
            var messagesViewMock = new Mock<IMessagesView>();
            messagesViewMock.Setup(v => v.GetMessages(userId)) // Trigger condition
                .Returns(new [] {message1, message2}) // Mocks call result
                .Verifiable(); // Plans verification at the end of the test
            var userRepositoryMock = new Mock<IUserRepository>();

            // Call testing method, messagesViewMock & userRepositoryMock calls inside
            var command = new GetNewestMessagesCommand(userRepositoryMock.Object, messagesViewMock.Object);
            var actualMessages = command.Execute(userId).ToArray();
            Assert.AreEqual(2, actualMessages.Count());
            Assert.AreEqual(message1.Text, actualMessages[0].Text);
            Assert.AreEqual(message1.UserSenderId, actualMessages[0].UserSenderId);
            Assert.AreEqual(message1.UserRecipientId, actualMessages[0].UserRecipientId);
            Assert.AreEqual(message2.Text, actualMessages[1].Text);
            Assert.AreEqual(message2.UserSenderId, actualMessages[1].UserSenderId);
            Assert.AreEqual(message2.UserRecipientId, actualMessages[1].UserRecipientId);
            // Verify planned call of messagesView
            messagesViewMock.Verify();
            // Check that command calls userRepository.SetLastViewedMessageId() with expected arguments
            userRepositoryMock.Verify(r => r.SetLastViewedMessageId(userId, message2.Id));
        }
    }
}