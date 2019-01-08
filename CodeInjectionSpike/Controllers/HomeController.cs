using System.Web.Mvc;

namespace CodeInjectionSpike.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("TEST");
        }

        public ActionResult TestMode()
        {
            return Content("IN TEST MODE");
        }

        public ActionResult Reset()
        {
            return Content("METHOD RESET");
        }
    }
}
