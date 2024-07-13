using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CloudHRMS.Controllers
{
    public class EmployeeController : Controller
    {      
        private readonly CloudHRMSApplicationDbContext _dbContext;
        //constcutror injection for ApplicationDbContext
        public EmployeeController(CloudHRMSApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Entry()
        {
            bindPositionData();
            bindDepartmentData();
            return View();
        }

        private void bindDepartmentData()
        {
            IList<DepartmentViewModel> positions = _dbContext.Departments.Where(w => !w.IsInActive).Select(s =>
            new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code + "/" + s.Name,
            }).ToList();
            ViewBag.Departments = positions;//passing the all of Departments to the UI
        }

        private void bindPositionData()
        {
            IList<PositionViewModel> positions = _dbContext.Positions.Where(w => !w.IsInActive).Select(s =>
           new PositionViewModel
           {
               Id = s.Id,
               Code = s.Code + "/" + s.Name,
           }).ToList();
            ViewBag.Positions = positions;//passing the all of position to the UI
        }

        [HttpPost]
        public IActionResult Entry(EmployeeViewModel ui)
        {
            try
            {
                //Data Exchange from view Model to Entity
                //ViewModels to Data Models 
                EmployeeEntity employeeEntity = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),//new random 36 char string ...
                   Code=ui.Code,
                   Name=ui.Name,
                   Email=ui.Email,
                   Phone=ui.Phone,
                   Gender=ui.Gender, 
                   DepartmentId=ui.DepartmentId,//adding the ralatiosnip key -departmentId
                   PositionId=ui.PositionId,//adding the ralatiosnip key - positionId
                    DOR =ui.DOR,
                   DOE=ui.DOE,
                   DOB=ui.DOB,
                   Address=ui.Address,
                   BasicSalary=ui.BasicSalary,
                    CreatedAt = DateTime.Now//set the current date time 
                };
                _dbContext.Employees.Add(employeeEntity);//add the entity to the dbContext.
                _dbContext.SaveChanges();//saving the record to the database.
                ViewData["Info"] = "Successfully save the recrod to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the recrod save to the system."+e.Message;
                ViewData["Status"] = false;
            }
            //for showing 
            bindPositionData();
            bindDepartmentData();
            return View();
        }
        public IActionResult List()
        {
            //DTO >>Data Transfer Object in here from DataModels to ViewModels
            IList<EmployeeViewModel> positions=_dbContext.Employees.Where(w=>!w.IsInActive).Select(s=>new EmployeeViewModel
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                DepartmentId = s.DepartmentId,
                PositionId = s.PositionId,
                DOR = s.DOR,
                DOE = s.DOE,
                DOB = s.DOB,
                Address = s.Address,
                BasicSalary = s.BasicSalary,
            }).ToList();
            return View(positions);//passing the position view models to the views
        }
/*        public IActionResult Edit(string id)
        {
            EmployeeViewModel positionView = _dbContext.Positions.Where(w => w.Id == id && !w.IsInActive).Select(s => new EmployeeViewModel
            {
                Id=s.Id,
                Code = s.Code,
                Name = s.Name,
                Level = s.Level,
                CreatedOn=s.CreatedAt,
                UpdatedOn=s.ModifiedAt
            }).FirstOrDefault();
            return View(positionView);
        }
        [HttpPost]
        public IActionResult Update(EmployeeViewModel positionViewModel)
        {
            try
            {
                //Data Exchange from view Model to Entity
                //ViewModels to Data Models 
                EmployeeEntity positionEntity = new EmployeeEntity()
                {
                    Id= positionViewModel.Id,
                    Code = positionViewModel.Code,
                    Name = positionViewModel.Name,
                    Level = positionViewModel.Level,
                    ModifiedAt = DateTime.Now,
                    CreatedAt=positionViewModel.CreatedOn
                };
                _dbContext.Positions.Update(positionEntity);//updae the entity to the dbContext.
                _dbContext.SaveChanges();//updating the record to the database.
                ViewData["Info"] = "Successfully update the recrod to the system.";
                ViewData["Status"] = true;
            }
            catch (Exception e)
            {
                ViewData["Info"] = "Error occur when the recrod update to the system." + e.Message;
                ViewData["Status"] = false;
            }
            return RedirectToAction("List");//when update success go to List View
        }
        public IActionResult Delete(string id)
        {
            try
            {
                EmployeeEntity positionEntity = _dbContext.Positions.Find(id);
                if (positionEntity != null)
                {
                    positionEntity.IsInActive = true;
                    _dbContext.Positions.Update(positionEntity);
                    _dbContext.SaveChanges();//saving the record to the database.
                    TempData["info"] = "Delete success when delete the record.";
                }
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when delete the record."+e.Message;
            }
            return RedirectToAction("List");//when delete success go to List View
        }*/
    }
}
