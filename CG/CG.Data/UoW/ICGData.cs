namespace CG.Data.UoW
{
    using CG.Data.Repositories;
    using CG.Models;

    public interface ICGData
    {
        IDeletableEntityRepository<Tag> Tags { get; }

        IRepository<User> Users { get; }

        IDeletableEntityRepository<CodeGist> CodeGists { get; }

        ICGDbContext Context { get; }

        int SaveChanges();
    }
}