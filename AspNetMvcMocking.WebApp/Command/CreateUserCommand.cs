using System;
using AspNetMvcMocking.WebApp.Models;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp.Command
{
    public interface ICreateUserCommand
    {
        Int32 Execute(UserModel userModel);
    }

    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository userRepository;

        public CreateUserCommand(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Int32 Execute(UserModel userModel)
        {
            var user = new User {Name = userModel.Name, Email = userModel.Email, CreateDate = DateTime.Now};
            return userRepository.Create(user);
        }
    }
}