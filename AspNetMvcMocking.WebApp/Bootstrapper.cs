using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using AspNetMvcMocking.WebApp.Command;
using AspNetMvcMocking.WebApp.Persistence;

namespace AspNetMvcMocking.WebApp
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IMessagesRepository, MessagesRepository>();
        container.RegisterType<IMessagesView, MessagesView>();
        container.RegisterType<IUserRepository, UserRepository>();
        container.RegisterType<ICreateMessageCommand, CreateMessageCommand>();
        container.RegisterType<IGetNewestMessagesCommand, GetNewestMessagesCommand>();
        container.RegisterType<IGetMessageCommand, GetMessageCommand>();

//        DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));
    }
  }
}