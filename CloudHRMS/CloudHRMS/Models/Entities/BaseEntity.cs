using CloudHRMS.Utilties;
using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }//primary key for database
        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }
        public string IpAddress { get; set; }= NewworkHelper.GetLocalIPAddress();//getting the local ip address of machine
        public bool IsInActive { get; set; }
    }
}
