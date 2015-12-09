namespace CG.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using CG.Contracts.Models;
    using CG.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class CGDbContext : IdentityDbContext<User>, ICGDbContext
    {
        public CGDbContext()
            : base("DefaultConnection", false)
        {
        }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<CodeGist> CodeGists { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public static CGDbContext Create()
        {
            return new CGDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeGist>()
                        .HasMany(x => x.Tags)
                        .WithMany(x => x.CodeGists)
                        .Map(
                            m =>
                            {
                                m.MapLeftKey("CodeGistId");
                                m.MapRightKey("TagId");
                                m.ToTable("CodeGistsTags");
                            });

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}