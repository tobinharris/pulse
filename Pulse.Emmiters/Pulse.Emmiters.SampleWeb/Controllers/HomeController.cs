using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulse.Emmiters.DotNet.Domain.MVC;

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
