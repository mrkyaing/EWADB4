using Microsoft.AspNetCore.Mvc;
using StudentRegistraion.Models;
using System.Diagnostics;

namespace StudentRegistraion.Controllers
{
    public class HomeController : Controller { 
    

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string name, string email, string password,
            string confirmPassword, string gender, DateTime dob, string city, string address)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Gender = gender;
            ViewBag.DOB = dob;
            ViewBag.City = city;
            ViewBag.Address = address;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}