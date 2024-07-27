using System.ComponentModel.DataAnnotations.Schema;
namespace CloudHRMS.Models.Entities
{
    [Table("Employee")]
    public class EmployeeEntity:BaseEntity
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
        public string PositionId { get; set; }//foreign key
        [ForeignKey(nameof(PositionId))]
        public virtual PositionEntity Position { get; set; }
        public string DepartmentId { get; set; }//foreign key
        [ForeignKey(nameof(DepartmentId))]
        public virtual DepartmentEntity Department { get; set; }
        public string? UserId { get; set; }
    }
}
