using CloudHRMS.DAO;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class PayrollController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _applicationDbContext;

        public PayrollController(CloudHRMSApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IActionResult List()
        {
            return View(_applicationDbContext.Payrolls.ToList());
        }
        public IActionResult PayrollProcess()
        {
            ViewBag.Employees = (_applicationDbContext.Employees.ToList());
            ViewBag.Departments = (_applicationDbContext.Departments.ToList());
            return View();
        }
        [HttpPost]
        public IActionResult PayrollProcess(PayrollViewModel ui)
        {
            try
            {
                //Data exchange from view model to data model by using automapper 
                { 
                  
                }
              //  _applicationDbContext.AttendanceMasters.AddRange(attendanceMasters);
                _applicationDbContext.SaveChanges();
                ViewBag.Info = "successfully save a record to the system";
            }
            catch (Exception ex)
            {
                ViewBag.Info = "Error occur when  saving a record  to the system";
            }
            return RedirectToAction("list");
        }
    }
}
