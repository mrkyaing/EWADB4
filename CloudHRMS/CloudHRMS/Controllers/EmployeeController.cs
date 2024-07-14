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
        public IActionResult Index()
        {
            //DTO >>Data Transfer Object in here from DataModels to ViewModels
            IList<EmployeeViewModel> employees=(from e in _dbContext.Employees
                                                join d in _dbContext.Departments
                                                on e.DepartmentId equals d.Id
                                                join p in _dbContext.Positions
                                                on e.PositionId equals p.Id
                                                where !e.IsInActive && !d.IsInActive && !p.IsInActive 
                                                    select new EmployeeViewModel{
                                                    Id = e.Id,
                                                    Code = e.Code,
                                                    Name = e.Name,
                                                    Email = e.Email,
                                                    Phone = e.Phone,
                                                    DepartmentId = e.DepartmentId,
                                                    PositionId = e.PositionId,
                                                    DOR = e.DOR,
                                                    DOE = e.DOE,
                                                    DOB = e.DOB,
                                                    Address = e.Address,
                                                    BasicSalary = e.BasicSalary,
                                                    DepartmentInfo=d.Code+"/"+d.Name,
                                                    PositionInfo =p.Code+"/"+p.Name
                                                }).ToList();
            return View(employees);//passing the position view models to the views
        }
               public IActionResult Edit(string id)
                {
                    EmployeeViewModel employeeView = _dbContext.Employees.Where(w => w.Id == id && !w.IsInActive).Select(s => new EmployeeViewModel
                    {
                        Id=s.Id,
                        Code = s.Code,
                        Name = s.Name,
                        Email =s.Email,
                        Phone = s.Phone,
                        Gender = s.Gender,
                        DepartmentId = s.DepartmentId,//adding the ralatiosnip key -departmentId
                        PositionId = s.PositionId,//adding the ralatiosnip key - positionId
                        DOR = s.DOR,
                        DOE = s.DOE,
                        DOB = s.DOB,
                        Address = s.Address,
                        BasicSalary = s.BasicSalary,
                        CreatedOn =s.CreatedAt,
                        UpdatedOn=s.ModifiedAt
                    }).FirstOrDefault();
                    //binding the department and position to the UI
                     bindDepartmentData();
                     bindPositionData();
                    return View(employeeView);
                }
                [HttpPost]
                public IActionResult Update(EmployeeViewModel ui)
                {
                    try
                    {
                        //Data Exchange from view Model to Entity
                        //ViewModels to Data Models 
                        EmployeeEntity employeeEntity = new EmployeeEntity()
                        {
                            Id= ui.Id,
                            Code = ui.Code,
                            Name = ui.Name,
                            Email = ui.Email,
                            Phone = ui.Phone,
                            Gender = ui.Gender,
                            DepartmentId = ui.DepartmentId,//adding the ralatiosnip key -departmentId
                            PositionId = ui.PositionId,//adding the ralatiosnip key - positionId
                            DOR = ui.DOR,
                            DOE = ui.DOE,
                            DOB = ui.DOB,
                            Address = ui.Address,
                            BasicSalary = ui.BasicSalary,
                            ModifiedAt = DateTime.Now,
                            CreatedAt=ui.CreatedOn
                        };
                        _dbContext.Employees.Update(employeeEntity);//updae the entity to the dbContext.
                        _dbContext.SaveChanges();//updating the record to the database.
                        ViewData["Info"] = "Successfully update the recrod to the system.";
                        ViewData["Status"] = true;
                    }
                    catch (Exception e)
                    {
                        ViewData["Info"] = "Error occur when the recrod update to the system." + e.Message;
                        ViewData["Status"] = false;
                    }
                    return RedirectToAction("index");//when update success go to List View
                }

        public IActionResult Delete(string id)
        {
            try
            {
                EmployeeEntity employeeEntity = _dbContext.Employees.Find(id);
                if (employeeEntity != null)
                {
                    employeeEntity.IsInActive = true;
                    _dbContext.Employees.Update(employeeEntity);
                    _dbContext.SaveChanges();//saving the record to the database.
                    TempData["info"] = "Delete success when delete the record.";
                }
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when delete the record."+e.Message;
            }
            return RedirectToAction("Index");//when delete success go to List View
        }
    }
}
