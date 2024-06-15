using Microsoft.AspNetCore.Mvc;
namespace HelloWebApp.Controllers
{
    public class RegisterController : Controller
    {
        //
        public int Add(){
            return 10+10;
        }

        public ViewResult Entry(){
            //declare the ViewBag at Server side 
            ViewBag.Info="Please Register Here";
            string[] friends=["Mg Mg","Su Su","Min Min"];
            ViewBag.Friends=friends;
            return View();
        }
    }
}