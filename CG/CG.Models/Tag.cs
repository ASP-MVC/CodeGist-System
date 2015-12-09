namespace CG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CG.Contracts;
    using CG.Contracts.Models;

    public class Tag : AuditInfo, IDeletableEntity, IEntity
    {
        public Tag()
        {
            this.CodeGists = new HashSet<CodeGist>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<CodeGist> CodeGists { get; set; }
    }
}