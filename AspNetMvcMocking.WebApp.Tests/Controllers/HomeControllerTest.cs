using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspNetMvcMocking.WebApp.Controllers;
using AspNetMvcMocking.WebApp.Models;

namespace AspNetMvcMocking.WebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
         [TestMethod]
         public void TestIndex()
         {
             var controller = new HomeController();
             var result = controller.Index() as ViewResult;
             Assert.IsNotNull(result);
             Assert.AreEqual(string.Empty, result.ViewName);
             var model = result.ViewData.Model as IndexModel;
             Assert.IsNotNull(model);
             Assert.AreEqual("Bar", model.Foo);
         }
    }
}