using System;
using System.Net;
using System.Web.Mvc;
using AspNetMvcMocking.WebApp.Command;

namespace AspNetMvcMocking.WebApp.Controllers
{
    public class SampleController : Controller
    {
        private readonly IGetMessageCommand getMessageCommand;

        public SampleController(IGetMessageCommand getMessageCommand)
        {
            this.getMessageCommand = getMessageCommand;
        }

        [HttpGet]
        public ActionResult GetMessage(Int64 messageId)
        {
            if (messageId < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = getMessageCommand.Execute(messageId);
            if (message != null)
            {
                return Json(message);
            }
            return new HttpNotFoundResult();
        }
    }
}
