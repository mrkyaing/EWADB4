using System.Linq.Expressions;
namespace CloudHRMS.Repositories.Common
{
    public interface IBaseRepository<T> where T:class
    {
        //CRUD Process for 
        void Create(T entity);
        IEnumerable<T> GetAll();
        //Delegate functions   dbContext.where();
        IEnumerable<T> GetBy(Expression<Func<T,bool>> expression);//preticate expression 
        void Update(T entity);
        void Delete(T entity);
    }
}
