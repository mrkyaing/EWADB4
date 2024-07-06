using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }//primary key for database
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public string IpAddress { get; set; }
        public bool IsInActive { get; set; }
    }
}
