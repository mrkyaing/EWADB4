using CloudHRMS.DAO;
using CloudHRMS.Models.ReportModels;

namespace CloudHRMS.Reportings
{
    public class Reporting : IReporting
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public Reporting(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)
        {
            this._cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }
        public IList<EmployeeDetail> EmployeeDetailReportBy(string fromEmployeeCode, string toEmployeeCode, string DepartmentId)
        {
            if(DepartmentId is not null)
            {
                var employeeDetails = (from e in _cloudHRMSApplicationDbContext.Employees
                                       join d in _cloudHRMSApplicationDbContext.Departments
                                       on e.DepartmentId equals d.Id
                                       join p in _cloudHRMSApplicationDbContext.Positions
                                       on e.PositionId equals p.Id
                                       where !e.IsInActive && !d.IsInActive && !p.IsInActive
                                       && e.DepartmentId == DepartmentId
                                       select new EmployeeDetail
                                       {
                                           Code = e.Code,
                                           Name = e.Name,
                                           Email = e.Email,
                                           Phone = e.Phone,
                                           DOR = e.DOR.Value.ToString("yyyy-MM-dd"),
                                           DOE = e.DOE.ToString("yyyy-MM-dd"),
                                           DOB = e.DOB.ToString("yyyy-MM-dd"),
                                           Address = e.Address,
                                           BasicSalary = e.BasicSalary,
                                           DepartmentInfo = d.Code + "/" + d.Name,
                                           PositionInfo = p.Code + "/" + p.Name
                                       }).ToList();        
                return employeeDetails;
            }
            else
            {
                var employeeDetails = (from e in _cloudHRMSApplicationDbContext.Employees
                                                           join d in _cloudHRMSApplicationDbContext.Departments
                                                           on e.DepartmentId equals d.Id
                                                           join p in _cloudHRMSApplicationDbContext.Positions
                                                           on e.PositionId equals p.Id
                                                           where !e.IsInActive && !d.IsInActive && !p.IsInActive
                                                           && (e.Code.CompareTo(fromEmployeeCode)>=0 && e.Code.CompareTo(toEmployeeCode)<=0)
                                                       select new EmployeeDetail
                                                       {
                                                           Code = e.Code,
                                                           Name = e.Name,
                                                           Email = e.Email,
                                                           Phone = e.Phone,
                                                           DOR = e.DOR.Value.ToString("yyyy-MM-dd"),
                                                           DOE = e.DOE.ToString("yyyy-MM-dd"),
                                                           DOB = e.DOB.ToString("yyyy-MM-dd"),
                                                           Address = e.Address,
                                                           BasicSalary = e.BasicSalary,
                                                           DepartmentInfo = d.Code + "/" + d.Name,
                                                           PositionInfo = p.Code + "/" + p.Name
                                                       }).ToList();
                return employeeDetails;
            }
        }
    }
}
