using Microsoft.AspNetCore.Mvc;

namespace HelloWebApp.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //hosting://server/example/fullname?firstname=Mg&lastname=Mg
        public ViewResult FullName(string firstName,string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                ViewBag.FullName = "Anymous user!!";
           else 
                ViewBag.FullName = $"Hi,I am {firstName} {lastName}";
            return View();
        }
        //query string 
        //hosting://port/example/sum?n1=100&n2=20
        [HttpGet]
        public IActionResult Sum(int n1,int n2)
        {
            ViewBag.Result=n1+n2;
            return View();
        }
        //hosting://port/example/download >> 404 
        [NonAction]
        [ActionName("download")]
        public FileResult DownloadFile()
        {
            string fileName = "Maxime.pdf";
            string filePath = Path.Combine("wwwroot/files/", fileName);
            byte[] contents=System.IO.File.ReadAllBytes(filePath);
            return File(contents,"text/pdf",fileName);
        }
        [HttpGet]
        public IActionResult Send() => View();
        //hosting://port/example/send
        [HttpPost]
        public IActionResult Send(string name,string message)
        {
            ViewBag.Info = $"Hello,{name}.I send this message {message}";
            return View();
        }
    }
}
