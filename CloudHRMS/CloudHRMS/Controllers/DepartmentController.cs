using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        public IActionResult List() => View(_departmentService.GetAll());
        [Authorize(Roles = "HR")]
        public IActionResult Edit(string id)
        { 
            return View(_departmentService.GetById(id));       
        }
        [Authorize(Roles = "HR")]
        public IActionResult Delete(string id)
        {
            try
            {
                _departmentService.Delete(id);
                TempData["Info"] = "Delete Successfully";
            }
            catch (Exception ex)
            {
                TempData["Info"] = "Error Occur When Deleting";
            }

            return RedirectToAction("List");
        }
        [Authorize(Roles = "HR")]
        public IActionResult Entry() => View();
        [Authorize(Roles = "HR")]
        [HttpPost]
        public IActionResult Entry(DepartmentViewModel ui)
        {
            try
            {
                //validation for existing codes
                var isAlreadyExist = _departmentService.IsAlreadyExist(ui);
                if (isAlreadyExist)
                {
                    ViewData["Info"] = "This Position code or name is already exist in the system.";
                    ViewData["Status"] = false;
                    return View(ui);
                }
                _departmentService.Create(ui);
                ViewData["Info"] = "Successfully save the recrod to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the recrod save to the system." + e.Message;
                ViewData["Status"] = false;
            }
            return View();
        }
    }
}
