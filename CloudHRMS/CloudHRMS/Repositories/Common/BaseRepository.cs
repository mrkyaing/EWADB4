using CloudHRMS.DAO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CloudHRMS.Repositories.Common
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CloudHRMSApplicationDbContext _cloudHRMSApplicationDbContext;
        //Generic Db Set for any Entity Models
        private readonly DbSet<T> _dbSet;
        public BaseRepository(CloudHRMSApplicationDbContext cloudHRMSApplicationDbContext)//Depedancy Injection 
        {
            _cloudHRMSApplicationDbContext = cloudHRMSApplicationDbContext;
            _dbSet =_cloudHRMSApplicationDbContext.Set<T>();//set and pass the defined DbSet Type to the DAO(Context)
        }
        public void Create(T entity)
        {
            _cloudHRMSApplicationDbContext.Add<T>(entity);
        }

        public void Delete(T entity)
        {
           _cloudHRMSApplicationDbContext.Update<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> expression)
        {
           return _dbSet.AsNoTracking().Where(expression).AsEnumerable();
        }

        public void Update(T entity)
        {
            _cloudHRMSApplicationDbContext.Update<T>(entity);
        }
    }
}
