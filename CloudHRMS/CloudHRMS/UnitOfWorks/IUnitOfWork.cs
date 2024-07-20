using CloudHRMS.Repositories.Domain;

namespace CloudHRMS.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //Register/Declare here for your repository Domains as A Unit Of Work ..................................
        IPositionRepository PositionRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }

        //Commit stages (insert,Update,Delete)
        void Commit();
        //Rollback transction
        void Roolback();
    }
}
