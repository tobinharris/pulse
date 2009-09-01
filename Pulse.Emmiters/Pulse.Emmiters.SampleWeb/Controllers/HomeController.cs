using System.Web.Mvc;
using Pulse.Observers.MVC;

namespace Pulse.Emmiters.SampleWeb.Controllers
{
    [HandleError]
    [Pulse]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
