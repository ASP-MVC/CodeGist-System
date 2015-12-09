namespace CG.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CG.Contracts;
    using CG.Contracts.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IEntity, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            // This will prevent UserManager of causing exception when registering new user
            this.CreatedOn = DateTime.Now;
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager)
        {
            var userIdentity =
                await
                manager.CreateIdentityAsync(
                    this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}