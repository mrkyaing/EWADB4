namespace CloudHRMS.Models.ViewModels
{
    public class PositionViewModel
    {
        public string Id { get; set; }//for edit/update and delete process.
        public string Code { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
