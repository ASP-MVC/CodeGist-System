namespace CG.Data.UoW
{
    using CG.Data.Repositories;
    using CG.Models;

    public class ICGData
    {
        IRepository<Tag> Tags { get; }

        IRepository<CodeGist> CodeGists { get; }
    }
}