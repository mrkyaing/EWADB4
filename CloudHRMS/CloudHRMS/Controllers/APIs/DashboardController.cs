using CloudHRMS.DAO;
using CloudHRMS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "HR")]
    public class DashboardController : ControllerBase
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public DashboardController(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)
        {
            this._cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }
        [HttpGet("chartdata")]
        public IActionResult GetChartData()
        {
            // Sample data, you can fetch this from a database
            //var data=_cloudHRMSApplicationDbContext.AttendanceMasters.Where(w=>!w.IsInActive).GroupBy().Select(s=>new AttendanceMonthly
            //{
            //    Labels=s.AttendanceDate.Month.ToString(),
            //})
            var monthlyAttendance = new AttendanceMonthly
            {
                Labels = new List<string> { "JAN", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" },
                Dataset1 = new List<int> { 5, 8, 30, 20, 40, 9, 25, 11 },
            };
            return Ok(monthlyAttendance);
        }
    }
}
