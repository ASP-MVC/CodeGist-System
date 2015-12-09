namespace CG.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ICGContext
    {
        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}