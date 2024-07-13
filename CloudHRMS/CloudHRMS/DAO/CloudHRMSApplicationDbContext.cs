using CloudHRMS.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.DAO
{
    public class CloudHRMSApplicationDbContext:DbContext
    {
        //Constructor changing to parent
        public CloudHRMSApplicationDbContext(DbContextOptions<CloudHRMSApplicationDbContext> options):base(options) {}
        //Register the DBSet Entities / Domain object to interface the database tables 
        public DbSet<PositionEntity>   Positions { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
