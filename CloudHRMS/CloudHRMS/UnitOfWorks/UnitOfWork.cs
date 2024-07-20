using CloudHRMS.DAO;
using CloudHRMS.Repositories.Domain;

namespace CloudHRMS.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;

        public UnitOfWork(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
        }
        
        //properties to create repository instance of class for Unit Of Work
        private IPositionRepository _positionRepository;
        public IPositionRepository PositionRepository
        {
            get
            {
                return _positionRepository= _positionRepository??new PositionRepository(_cloudHRMSApplicationDbContext);
            }
        }

        public void Commit()
        {
           _cloudHRMSApplicationDbContext.SaveChanges();
        }

        public void Roolback()
        {
            _cloudHRMSApplicationDbContext.Dispose();
        }

    }
}
