namespace CG.Data
{
    using CG.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class CGDbContext : IdentityDbContext<User>
    {
        public CGDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static CGDbContext Create()
        {
            return new CGDbContext();
        }
    }
}