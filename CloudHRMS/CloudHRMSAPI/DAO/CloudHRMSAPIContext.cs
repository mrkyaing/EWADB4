using CloudHRMSAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMSAPI.DAO
{
    public class CloudHRMSAPIContext:DbContext
    {
        public CloudHRMSAPIContext(DbContextOptions<CloudHRMSAPIContext> contextOptions):base(contextOptions)
        {
            
        }
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
