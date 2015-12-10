namespace CG.Web.Models.BindingModel
{
    using System.ComponentModel.DataAnnotations;

    using CG.Infrastructure.Mappings;
    using CG.Models;

    public class TagBindingModel : IMapTo<Tag>
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }
    }
}