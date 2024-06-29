using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BindingPractice.Models;

namespace BindingPractice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

   public IActionResult Register()=>View();
   
   [HttpPost]
   public IActionResult Register(EmployeeModel employeeModel){
    ViewData["Info"]=$"Hello,{employeeModel.Name} is registerd at the country {employeeModel.HomeAddress.Country}.";
    return View();
   }

   public IActionResult RegisterAsList()=>View();
   [HttpPost]
   public IActionResult RegisterAsList(IList<EmployeeModel> employeeModels){
    ViewData["Info"]=$"Total Register Count:{employeeModels.Count}";
    return View();
   }
}
