using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IDepartmentService
    {
        //Create 
        void Create(DepartmentViewModel vm);
        //Reterive
        IEnumerable<DepartmentViewModel> GetAll();
        //GetById
        DepartmentViewModel GetById(string id);
        //Update 
        void Update(DepartmentViewModel vm);
        //delete 
        bool Delete(string Id);
        //checking already exist data 
        bool IsAlreadyExist(DepartmentViewModel vm);
    }
}
