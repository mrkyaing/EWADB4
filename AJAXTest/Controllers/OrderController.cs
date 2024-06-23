using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AJAXTest.Models;

namespace AJAXTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private static int _totalCount = 0;
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string TellMeNow()
        {
            return DateTime.Now.ToString();//2024-06-23 20:55
        }
        public int ShowCount()
        {
            _totalCount++;
            return _totalCount;
        }
        public IActionResult MakeOrder() => View();
        
        [HttpPost]
        public JsonResult MakeOrder(OrderModel orderModel)
        {
            orderModel.TotalCost=orderModel.Quantity*orderModel.Amount;
            return Json(orderModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}