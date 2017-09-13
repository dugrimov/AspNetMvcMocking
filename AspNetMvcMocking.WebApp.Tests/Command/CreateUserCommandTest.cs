using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AspNetMvcMocking.WebApp.Command;
using AspNetMvcMocking.WebApp.Models;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.Tests.Command
{
    [TestClass]
    public class CreateUserCommandTest
    {
        [TestMethod]
        public void TestExecute()
        {
            // Creates the object that command will pass to the repository
            var userModel = new UserModel {Name = "John", Email = "john@test.com" };
            const int expectedUserId = 2;
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(r => r.Create(It.Is<User>(
                    // Check dao object passed from command to repository
                    u => u.Id.Equals(0) && u.Name.Equals(userModel.Name) && u.Email.Equals(userModel.Email) && u.CreateDate != null
                )))
                .Returns(expectedUserId)
                .Verifiable(); // Plans verification at the end of the test
            var command = new CreateUserCommand(userRepositoryMock.Object);
            var actualUserId = command.Execute(userModel);
            Assert.AreEqual(expectedUserId, actualUserId);
            userRepositoryMock.Verify(); // Verify planed call 
        }
    }
}