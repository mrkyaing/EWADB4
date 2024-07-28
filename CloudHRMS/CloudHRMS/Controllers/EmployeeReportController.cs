using CloudHRMS.DAO;
using CloudHRMS.Models.ReportModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Reportings;
using CloudHRMS.Utilties;
using Microsoft.AspNetCore.Mvc;
namespace CloudHRMS.Controllers
{
    public class EmployeeReportController : Controller
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;
        private readonly IReporting _reporting;
        public EmployeeReportController(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext,IReporting reporting)
        {
            this._cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
            this._reporting = reporting;
        }
        public IActionResult EmployeeDetailReport()
        {
            bindEmployeeData();
            bindDepartmentData();
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeDetailReport(string FromEmployeeCode, string ToEmployeeCode,string DepartmentId)
        {
         IList<EmployeeDetail>   employeeDetails= _reporting.EmployeeDetailReportBy(FromEmployeeCode, ToEmployeeCode, DepartmentId);
            string fileName = $"EmployeeDetailsReport{DateTime.Now.ToString()}.xlsx";
            if (employeeDetails.Any())
            {
             var fileContentsInBytes=   ReportHelper.ExportToExcel(employeeDetails, fileName);
                var contentType = "application/vnd.openxmlformat-officedocument.spreadsheet.sheet";
                ViewData["Info"] = "Successfully save the recrod to the system.";
                ViewData["Status"] = true;
                return File(fileContentsInBytes,contentType,fileName);
            }
            else
            {
                bindEmployeeData();
                bindDepartmentData();
                ViewData["Info"] = "Error occur when the recrod save to the system.";
                ViewData["Status"] = false;
                return View();
            }
        }
        private void bindEmployeeData()
        {
            IList<EmployeeViewModel> positions = _cloudHRMSApplicationDbContext.Employees.Where(w => !w.IsInActive).Select(s =>
             new EmployeeViewModel
             {
                 Id = s.Id,
                 Code = s.Code + "/" + s.Name
             }).ToList();
            ViewBag.Employees = positions;
        }
        private void bindDepartmentData()
        {
            IList<DepartmentViewModel> departments = _cloudHRMSApplicationDbContext.Departments.Where(w => !w.IsInActive).Select(s =>
            new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code + "/" + s.Name
            }).ToList();
            ViewBag.Departments = departments;
        }
    }
}
