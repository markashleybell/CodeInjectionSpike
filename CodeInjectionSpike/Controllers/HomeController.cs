using System;
using System.Web.Mvc;
using Harmony;

namespace CodeInjectionSpike.Controllers
{
    public class HomeController : Controller
    {
        private readonly HarmonyInstance _harmony = HarmonyInstance.Create("CodeInjectionSpike");

        public ActionResult Index() => Content("TEST");

        public ActionResult TestMode()
        {
            var original = GetType().GetMethod("Index");
            var prefix = GetType().GetMethod("ThrowException");

            _harmony.Patch(original, new HarmonyMethod(prefix));

            return Content("IN TEST MODE");
        }

        public ActionResult Reset()
        {
            _harmony.UnpatchAll("CodeInjectionSpike");

            return Content("METHOD RESET");
        }

        // NOTE: Pre/postfix methods must be static; otherwise, rewriting
        // their parent class will generate an invalid program
        public static void ThrowException() =>
            throw new Exception("TEST EXCEPTION");
    }
}
