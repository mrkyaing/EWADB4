
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApp.Controllers
{
    public class HomeController:Controller
    {
        //action method 
        //localhost:7022/home/Hi
        public string Hi(){
            return "Hello,I come from home controller";
        }
        
        //hosting:port/Home/GetNow
        public string GetNow(){
            return DateTime.Now.ToString();
        }
       //Good Way
       public ViewResult GoToIndex(){
        return View("Index");
       }
     public ViewResult goToIndex(){
        return View("Index");
       }
       public ViewResult Index(){
        return View();
       }
       //coding  is the art of programming.
       //hosting:port/home/welcome
       public ViewResult Welcome(){
            ViewData["Day"]= "Sunday";
        return View();
       }
    }
}