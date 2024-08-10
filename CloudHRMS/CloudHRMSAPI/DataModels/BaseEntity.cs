
using CloudHRMSAPI.Utilties;
using System.ComponentModel.DataAnnotations;

namespace CloudHRMSAPI.DataModels
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }//primary key for database
        public DateTime CreatedAt { get; set; } 
        public DateTime? ModifiedAt { get; set; }//0001-00-01
        public string IpAddress { get; set; }= NetworkHelper.GetLocalIPAddress();//getting the local ip address of machine
        public bool IsInActive { get; set; }
    }
}
