using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace WorkOut.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //create a Index.cshtml in Views\Home\Index.cshtml ?? asp.net Core Conversion Style
        public IActionResult Index()
        {
            return View();
        }

    }
}