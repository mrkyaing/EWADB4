using Microsoft.AspNetCore.Mvc;
namespace HelloWebApp.Controllers
{
    public class RegisterController : Controller
    {
        //
        public int Add()
        {
            return 10 + 10;
        }

        public ViewResult Entry()
        {
            //declare the ViewBag at Server side 
            ViewBag.Info = "Please Register Here";
            string[] friends = ["Mg Mg", "Su Su", "Min Min"];
            ViewBag.Friends = friends;
            return View();
        }
        [HttpGet]
        public IActionResult Send() => View();
        [HttpPost]
        public IActionResult Send(string message)
        {
            TempData["info"] = message;
            return View();
        }

        public IActionResult List()
        {
            var m=TempData["info"];
            ViewData["info"] = m;
            return View();
        }

        public IActionResult About()
        {
            var m = TempData["info"];
            //ViewData["info"] = m;
            return View();
        }
    }
}