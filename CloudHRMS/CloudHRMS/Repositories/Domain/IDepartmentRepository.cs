using CloudHRMS.Models.Entities;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public interface IDepartmentRepository:IBaseRepository<DepartmentEntity>
    {
        //customization code logic here 
        bool IsAlreadyExist(string Code, string Name);
    }
}
