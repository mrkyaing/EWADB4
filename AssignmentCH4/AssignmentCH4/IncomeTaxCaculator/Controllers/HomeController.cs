using IncomeTaxCaculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IncomeTaxCaculator.Controllers
{
    public class HomeController : Controller
    {
       string NetIncomeTax(int incomeTax)
        {
            int net_income_tax = 0;
            string message = "";
            if (incomeTax < 500000)
            {
                message =  "သင်အခွန်ပေးဆောင်ရန် မလိုသေးပါ။";
            }
            else if (incomeTax >= 500000 || incomeTax < 600000)
            {
                net_income_tax = Convert.ToInt32(incomeTax * 0.05);
                message =  $"သင်ပေးဆောင်ရမည့်အခွန်‌‌ငွေမှာ တစ်လလျှင် {net_income_tax} ဖြစ်ပြီး တစ်နှစ်လျှင် {net_income_tax * 12} ဖြစ်ပါသည်။";
            }
            else if (incomeTax >= 600000 || incomeTax < 700000)
            {
                net_income_tax = Convert.ToInt32(incomeTax * 0.06);
                message =  $"သင်ပေးဆောင်ရမည့်အခွန်‌‌ငွေမှာ တစ်လလျှင် {net_income_tax}  ဖြစ်ပြီး တစ်နှစ်လျှင်  {net_income_tax * 12} ဖြစ်ပါသည်။";

            }
            else if (incomeTax >= 700000)
            {
                net_income_tax = Convert.ToInt32(net_income_tax * 0.07);
                message =  $"သင်ပေးဆောင်ရမည့်အခွန်‌‌ငွေမှာ တစ်လလျှင် {net_income_tax}  ဖြစ်ပြီး တစ်နှစ်လျှင်  {net_income_tax * 12} ဖြစ်ပါသည်။";
            }
            return message;
        }
       public IActionResult Index()=>View();

        [HttpPost]
        public IActionResult Index(int income, bool hasFather, bool hasMother, string maritalStatus, int children)
        {
            int net_income = 0;
            int benefit_for_has_father_or_mother = 50000;
            int benefit_for_has_father = 50000;
            int benefit_for_has_mother = 50000;
            int benefit_for_one_child = 30000;
            int benefit_for_two_child = 60000;


            if (!hasFather && !hasMother && maritalStatus == "Single") {
                net_income = income;
                ViewBag.Message =  NetIncomeTax(net_income);
                
            }
            else if((hasFather && hasMother) && maritalStatus == "Single")
            {

                net_income = income - (benefit_for_has_father + benefit_for_has_mother);
                ViewBag.Message = NetIncomeTax(net_income);

            }
            else if ((!hasFather && hasMother) && maritalStatus == "Single")
            {

                net_income = income - benefit_for_has_father_or_mother;
                ViewBag.Message = NetIncomeTax(net_income);

            }
            else if ((hasFather && !hasMother) && maritalStatus == "Single")
            {

                net_income = income - benefit_for_has_father_or_mother;
                ViewBag.Message = NetIncomeTax(net_income);

            }
            else if(hasFather && hasMother && maritalStatus == "Single")
            {
               
                net_income = income - (benefit_for_has_father + benefit_for_has_mother);
                ViewBag.Message = NetIncomeTax(net_income);
            }
            else if(!hasFather && !hasMother && maritalStatus == "Married")
            {
                if(children == 1)
                {
                    net_income = income - benefit_for_one_child;
                    ViewBag.Message = NetIncomeTax(net_income);
                }
                else if(children >= 2)
                {
                    net_income = income - benefit_for_two_child;
                    ViewBag.Message = NetIncomeTax(net_income);
                }
            }
            else if((hasFather && hasMother) && maritalStatus == "Married")
            {
                if(children == 1)
                {
                    net_income = income - (benefit_for_has_father + benefit_for_has_mother + benefit_for_one_child);
                    ViewBag.Message = NetIncomeTax(net_income);
                }

                else if(children >= 2)
                {
                    net_income = income - (benefit_for_has_father + benefit_for_has_mother + benefit_for_one_child);
                    ViewBag.Message = NetIncomeTax(net_income);
                }
            }
            else if(!hasFather && hasMother && maritalStatus == "Married")
            {
                if(children == 1)
                {
                    net_income = income - (benefit_for_has_father_or_mother + benefit_for_one_child);
                    ViewBag.Message = NetIncomeTax(net_income);
                }
                else if(children >= 2)
                {
                    net_income = income - (benefit_for_has_father_or_mother + benefit_for_two_child);
                    ViewBag.Message = NetIncomeTax(net_income);
                }
            }
            else if (hasFather && !hasMother && maritalStatus == "Married")
            {
                if (children == 1)
                {
                    net_income = income - (benefit_for_has_father_or_mother + benefit_for_one_child);
                    ViewBag.Message = NetIncomeTax(net_income);
                }
                else if (children >= 2)
                {
                    net_income = income - (benefit_for_has_father_or_mother + benefit_for_two_child);
                    ViewBag.Message = NetIncomeTax(net_income);
                }
            }

            return View();
        }
    }
}