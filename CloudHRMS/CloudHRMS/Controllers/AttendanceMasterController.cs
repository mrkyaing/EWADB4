using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class AttendanceMasterController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _applicationDbContext;

        public AttendanceMasterController(CloudHRMSApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IActionResult List()
        {
            //mapper.map<source,destination>(dataList);
            return View(_applicationDbContext.AttendanceMasters.Select(s=>new AttendanceMasterViewModel
            {
                Id = s.Id,
                AttendanceDate = s.AttendanceDate,
                InTime = s.InTime,
                OutTime = s.OutTime,
                IsEarlyOut = s.IsEarlyOut,
                IsLate =s.IsLate,
            }).ToList());
        }
        public IActionResult DayEndProcess()
        {
            ViewBag.Shifts =(_applicationDbContext.Shifts.ToList());
            ViewBag.Employees = (_applicationDbContext.Employees.ToList());
            ViewBag.Departments = (_applicationDbContext.Departments.ToList());
            return View();
        }
        [HttpPost]
        public IActionResult DayEndProcess(AttendanceMasterViewModel ui)
        {
            try
            {
                //Data exchange from view model to data model by using automapper 
                List<AttendanceMasterEntity> attendanceMasters = new List<AttendanceMasterEntity>();         
                var DailyAttendancesWithShiftAssignsData = (from d in _applicationDbContext.DailyAttendances
                            join sa in _applicationDbContext.ShiftAssigns
                            on d.EmployeeId equals sa.EmployeeId
                            where sa.EmployeeId == ui.EmployeeId &&
                                        (ui.AttendanceDate >= sa.FromDate && sa.FromDate <= ui.ToDate)
                            select new
                            {
                                dailyAttendance=d,
                                shiftAssign=sa
                            }).ToList();             
                foreach(var data in DailyAttendancesWithShiftAssignsData)
                {
                    ShiftEntity definedShift = _applicationDbContext.Shifts.Where(s => s.Id == data.shiftAssign.ShiftId).SingleOrDefault() ;
                    if(definedShift is not null)
                    {
                        AttendanceMasterEntity attendanceMaster = new AttendanceMasterEntity();
                        attendanceMaster.Id = Guid.NewGuid().ToString();
                        attendanceMaster.CreatedAt = DateTime.Now;
                        attendanceMaster.IsLeave = false;
                        attendanceMaster.InTime = data.dailyAttendance.InTime;
                        attendanceMaster.OutTime = data.dailyAttendance.OutTime;
                        attendanceMaster.EmployeeId = data.shiftAssign.EmployeeId;
                        attendanceMaster.ShiftId = definedShift.Id;
                        attendanceMaster.DepartmentId = data.dailyAttendance.DepartmentId;
                        attendanceMaster.AttendanceDate = data.dailyAttendance.AttendanceDate;
                        //checking out the late status 
                        if (data.dailyAttendance.InTime> definedShift.LateAfter)
                        {
                            attendanceMaster.IsLate = true;
                        }
                        else
                        {
                            attendanceMaster.IsLate = false;
                        }
                        //checking out the late status 
                        if (data.dailyAttendance.OutTime < definedShift.EarlyOutBefore)
                        {
                            attendanceMaster.IsEarlyOut = true;
                        }
                        else
                        {
                            attendanceMaster.IsEarlyOut = false;
                        }
                        attendanceMasters.Add(attendanceMaster);
                    }//end of the deifned shift not null 
                
                }
                _applicationDbContext.AttendanceMasters.AddRange(attendanceMasters);
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
