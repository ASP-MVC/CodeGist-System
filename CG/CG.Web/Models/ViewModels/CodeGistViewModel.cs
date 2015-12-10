namespace CG.Web.Models.ViewModels
{
    using CG.Infrastructure.Mappings;
    using CG.Models;

    public class CodeGistViewModel : IMapFrom<CodeGist>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public UserViewModel Owner { get; set; }
    }
}