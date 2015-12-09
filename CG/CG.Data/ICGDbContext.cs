namespace CG.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using CG.Models;

    public interface ICGDbContext
    {
        IDbSet<Tag> Tags { get; set; }

        IDbSet<CodeGist> CodeGists { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}