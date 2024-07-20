using CloudHRMS.Models.Entities;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
namespace CloudHRMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(DepartmentViewModel ui)
        {
            //Data exchange from view model to data model
            var organization = new DepartmentEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Code = ui.Code,
                Name = ui.Name,
                ExtensionPhone = ui.ExtensionPhone
            };
            _unitOfWork.DepartmentRepository.Create(organization);//store the object in dbSets
            _unitOfWork.Commit();//actually commit/save the data to the database
        }

        public bool Delete(string Id)
        {
            try
            {
                var entity = _unitOfWork.DepartmentRepository.GetBy(x => x.Id == Id).SingleOrDefault();
                if (entity != null)
                {
                    entity.IsInActive = true;
                    _unitOfWork.DepartmentRepository.Delete(entity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<DepartmentViewModel> GetAll()
        {
           return _unitOfWork.DepartmentRepository.GetAll().Select(
                s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    ExtensionPhone = s.ExtensionPhone,
                    TotalEmployeeCount = 0//_unitOfWork.re.Where(e => e.DepartmentId == s.Id).Count()
                }).ToList();
        }

        public DepartmentViewModel GetById(string id)
        {
          return _unitOfWork.DepartmentRepository.GetBy(w => w.Id == id && !w.IsInActive).Select(s => new DepartmentViewModel{
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
               ExtensionPhone=s.ExtensionPhone,
                CreatedOn = s.CreatedAt,
                UpdatedOn = s.ModifiedAt
            }).FirstOrDefault();
        }

        public bool IsAlreadyExist(DepartmentViewModel vm)
        {
        return   _unitOfWork.PositionRepository.IsAlreadyExist(vm.Code, vm.Name);
        }

        public void Update(DepartmentViewModel vm)
        {
                var department = new DepartmentEntity(){
                Id = vm.Id,
                Code = vm.Code,
                Name = vm.Name,
                ExtensionPhone = vm.ExtensionPhone,
                ModifiedAt = DateTime.Now,
                CreatedAt = vm.CreatedOn
            };
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Commit();
        }
    }
}
