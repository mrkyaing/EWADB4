namespace CloudHRMSAPI.Models
{
    public class EmployeeModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public string? Address { get; set; }
        public decimal BasicSalary { get; set; }
        public string? Phone { get; set; }
        public string PositionId { get; set; }
        public string? PositionInfo { get; set; }
        public string DepartmentId { get; set; }
        public string? DepartmentInfo { get; set; }
        public string UserId { get; set; }
    }
}
