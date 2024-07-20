using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(PositionViewModel positionViewModel)
        {
            //Data Exchange from view Model to Entity
            //ViewModels to Data Models 
            PositionEntity positionEntity = new PositionEntity()
            {
                Id = Guid.NewGuid().ToString(),//new random 36 char string ...
                Code = positionViewModel.Code,
                Name = positionViewModel.Name,
                Level = positionViewModel.Level,
                CreatedAt = DateTime.Now//set the current date time 
            };
            _unitOfWork.PositionRepository.Create(positionEntity);//store the object in dbSets
            _unitOfWork.Commit();//actually commit/save the data to the database
        }

        public bool Delete(string Id)
        {
            try
            {
                PositionEntity positionEntity = _unitOfWork.PositionRepository.GetBy(x => x.Id == Id).SingleOrDefault();
                if (positionEntity != null)
                {
                    positionEntity.IsInActive = true;
                    _unitOfWork.PositionRepository.Delete(positionEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<PositionViewModel> GetAll()
        {
            //DTO >>Data Transfer Object in here from DataModels to ViewModels
              return  _unitOfWork.PositionRepository.GetAll().Where(w => !w.IsInActive).Select(s => new PositionViewModel{
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Level = s.Level
            }).AsEnumerable();
        }

        public PositionViewModel GetById(string id)
        {
          return _unitOfWork.PositionRepository.GetBy(w => w.Id == id && !w.IsInActive).Select(s => new PositionViewModel{
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Level = s.Level,
                CreatedOn = s.CreatedAt,
                UpdatedOn = s.ModifiedAt
            }).FirstOrDefault();
        }

        public bool IsAlreadyExist(PositionViewModel positionViewModel)
        {
        return   _unitOfWork.PositionRepository.IsAlreadyExist(positionViewModel.Code, positionViewModel.Name);
        }

        public void Update(PositionViewModel positionViewModel)
        {
                PositionEntity positionEntity = new PositionEntity(){
                Id = positionViewModel.Id,
                Code = positionViewModel.Code,
                Name = positionViewModel.Name,
                Level = positionViewModel.Level,
                ModifiedAt = DateTime.Now,
                CreatedAt = positionViewModel.CreatedOn
            };
            _unitOfWork.PositionRepository.Update(positionEntity);
            _unitOfWork.Commit();
        }
    }
}
