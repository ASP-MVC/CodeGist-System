namespace CG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CG.Contracts;
    using CG.Contracts.Models;

    public class CodeGist : AuditInfo, IDeletableEntity, IEntity
    {
        public CodeGist()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}