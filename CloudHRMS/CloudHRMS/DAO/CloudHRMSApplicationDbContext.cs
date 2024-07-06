using CloudHRMS.Models;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.DAO
{
    public class CloudHRMSApplicationDbContext:DbContext
    {
        public CloudHRMSApplicationDbContext(DbContextOptions<CloudHRMSApplicationDbContext> options):base(options) {}//Constructor changing to parent
        //Register the DBSet Entities / Domain object to interface the database tables 
        public DbSet<PositionEntity>   Positions { get; set; }
    }
}
