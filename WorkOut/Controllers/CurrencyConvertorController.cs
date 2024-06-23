using Microsoft.AspNetCore.Mvc;//for mvc process
using Microsoft.Extensions.Logging;// for looging 

namespace WorkOut.Controllers
{
    public class CurrencyConvertorController : Controller
    {
        private readonly ILogger<CurrencyConvertorController> _logger;
        //Depedency injection for ILogger 
        public CurrencyConvertorController(ILogger<CurrencyConvertorController> logger)
        {
            //initialize for _logger object 
            _logger = logger;
        }

        public IActionResult ConvertorV1()
        {
            return View();
        }
        //simple binding apporach [html name bind to action method parameter]
        [HttpPost]
        public IActionResult ConvertorV1(decimal amount, string selectedCurrency)
        {
            switch (selectedCurrency)
            {
                case "usd": ViewData["result"] = amount * 3000; break;
                case "sdg": ViewData["result"] = amount * 2500; break;
                case "baht": ViewData["result"] = amount * 120; break;
                default: ViewData["result"] = "Nothings"; break;
            }
            return View();
        }
        public IActionResult ConvertorV2() => View();//lambada style 

        [HttpPost]
        public IActionResult ConvertorV2(decimal amount, string selectedCurrency)
        {
            if(amount<0 || "".Equals(selectedCurrency)){
                return View();
            }          
            ViewData["selectedCurrency"]=selectedCurrency;
            ViewData["InputedAmount"]=amount;
            switch (selectedCurrency)
            {
                case "usd": ViewData["result"] = amount * 3000; break;
                case "sdg": ViewData["result"] = amount * 2500; break;
                case "baht": ViewData["result"] = amount * 120; break;
                default: ViewData["result"] = "Nothings"; break;
            }
            return View();
        }
    }
}