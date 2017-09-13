using System.Web.Mvc;
using AspNetMvcMocking.WebApp.Models;

namespace AspNetMvcMocking.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexModel { Foo = "Bar"});
        }
    }
}
