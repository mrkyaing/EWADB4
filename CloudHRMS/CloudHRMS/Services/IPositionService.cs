using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IPositionService
    {
        //Create 
        void Create(PositionViewModel positionViewModel);
        //Reterive
        IEnumerable<PositionViewModel> GetAll();
        //GetById
        PositionViewModel GetById(string id);
        //Update 
        void Update(PositionViewModel positionViewModel);
        //delete 
        bool Delete(string Id);
        //checking already exist data 
        bool IsAlreadyExist(PositionViewModel positionViewModel);
    }
}
