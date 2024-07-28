using CloudHRMS.Models.ReportModels;

namespace CloudHRMS.Reportings
{
    public interface IReporting
    {
        IList<EmployeeDetail> EmployeeDetailReportBy(string fromEmployeeCode, string toEmployeeCode,string departmentId);
    }
}
