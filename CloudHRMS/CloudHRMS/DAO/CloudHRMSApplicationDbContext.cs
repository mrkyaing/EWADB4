using CloudHRMS.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CloudHRMS.DAO
{
    public class CloudHRMSApplicationDbContext:IdentityDbContext<IdentityUser,IdentityRole,string>{
        //Constructor changing to parent
        public CloudHRMSApplicationDbContext(DbContextOptions<CloudHRMSApplicationDbContext> options):base(options) {}
        //Register the DBSet Entities / Domain objects to interface the database tables 
        public DbSet<PositionEntity>   Positions { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DailyAttendanceEntity> DailyAttendances { get; set; }
        public DbSet<ShiftEntity> Shifts { get; set; }
        public DbSet<AttendancePolicyEntity> AttendancePolicies { get; set; }
        public DbSet<ShiftAssignEntity> ShiftAssigns { get; set; }
        public DbSet<AttendanceMasterEntity> AttendanceMasters { get; set; }
        public DbSet<PayrollEntity> Payrolls { get; set; }
    }
}
