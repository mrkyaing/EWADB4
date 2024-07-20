using CloudHRMS.DAO;
using CloudHRMS.Models.Entities;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class DepartmentRepository : BaseRepository<DepartmentEntity>, IDepartmentRepository
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public DepartmentRepository(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext) : base(cloudHRMSApplicationDbContext)//Constructor changing
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }
        //code your custom implemenation for position functions 
        public bool IsAlreadyExist(string Code, string Name)=> _cloudHRMSApplicationDbContext.Departments.Where(w => (w.Code != Code && w.Name == Name) && !w.IsInActive).Any();

    }
}
