using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AspNetMvcMocking.WebApp.Command;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.Tests.Command
{
    [TestClass]
    public class CreateMessageCommandTest
    {
        [TestMethod]
        public void TestExecute()
        {
            // Initialize source data
            const string expectedText = "Hello, world!";
            const int expectedUserSenderId = 111;
            const int expectedUserRecipientId = 222;
            const long expectedMessageId = 999L;
            Message actualMessage = null;
            var messagesRepositoryMock = new Mock<IMessagesRepository>();
            messagesRepositoryMock.Setup(r => r.CreateMessage(It.IsAny<Message>()))
                .Callback<Message>(m => actualMessage = m) // Callback() saves actual parameter into local variable
                .Returns(expectedMessageId);
            
            var command = new CreateMessageCommand(messagesRepositoryMock.Object);
            // Call testing method with agrs
            var actualMessageId = command.Execute(expectedText, expectedUserSenderId, expectedUserRecipientId);
            Assert.AreEqual(expectedMessageId, actualMessageId);
            // Check that the command build DAO object correctly 
            Assert.IsNotNull(actualMessage);
            Assert.AreEqual(expectedText, actualMessage.Text);
            Assert.AreEqual(expectedUserSenderId, actualMessage.UserSenderId);
            Assert.AreEqual(expectedUserRecipientId, actualMessage.UserRecipientId);
            Assert.IsNotNull(actualMessage.MessageDate);
        }
    }
}