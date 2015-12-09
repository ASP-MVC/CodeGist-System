namespace CG.Data.Repositories
{
    using System.Linq;

    using CG.Contracts;

    public interface IDeletableEntityRepository<T> : IRepository<T>
        where T : IEntity
    {
        IQueryable<T> AllWithDeleted();
    }
}