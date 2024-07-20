using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;
namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        public IActionResult Entry()
        {
            PositionViewModel positionViewModel = new PositionViewModel()
            {
                Level = 1,
            };
            return View(positionViewModel);
        }
       
        [HttpPost]
        public IActionResult Entry(PositionViewModel positionViewModel)
        {
            try
            {
                //validation for existing codes
                var isAlreadyExist=_positionService.IsAlreadyExist(positionViewModel);
                if (isAlreadyExist)
                {
                    ViewData["Info"] = "This Position code or name is already exist in the system.";
                    ViewData["Status"] = false;
                    return View(positionViewModel);
                }
                _positionService.Create(positionViewModel);
                ViewData["Info"] = "Successfully save the recrod to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the recrod save to the system."+e.Message;
                ViewData["Status"] = false;
            }
            return View(positionViewModel);
        }
        public IActionResult List()
        {
            var positions = _positionService.GetAll();
            return View(positions);//passing the position view models to the views
        }
        public IActionResult Edit(string id)
        {
            PositionViewModel positionViewModel =_positionService.GetById(id);
            return View(positionViewModel);
        }
        [HttpPost]
        public IActionResult Update(PositionViewModel positionViewModel)
        {
            try
            {
                //Data Exchange from view Model to Entity
                //ViewModels to Data Models 
                var isAlreadyExists=_positionService.IsAlreadyExist(positionViewModel);
                if (isAlreadyExists)
                {
                    return View("Edit", positionViewModel);
                }
               _positionService.Update(positionViewModel);
                TempData["info"] = "Successfully update the recrod to the system.";
                TempData["Status"] = true;
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when the recrod update to the system." + e.Message;
                TempData["Status"] = false;
                return View("Edit", positionViewModel);
            }
            return RedirectToAction("List");//when update success go to List View
        }
        public IActionResult Delete(string id)
        {
            try
            {          
                 _positionService.Delete(id);
                 TempData["info"] = "Delete success when delete the record.";
                TempData["Status"] = false;
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when delete the record."+e.Message;
                TempData["Status"] = false;
            }
            return RedirectToAction("List");//when delete success go to List View
        }
    }
}
