namespace CloudHRMS.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ExtensionPhone { get; set; }
        public int TotalEmployeeCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
