using System.Collections.Generic;
using AutoMapper;

namespace CG.Web.Models.ViewModels
{
    using CG.Infrastructure.Mappings;
    using CG.Models;

    public class CodeGistViewModel : IMapFrom<CodeGist>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public UserViewModel Owner { get; set; }

        public  IEnumerable<TagViewModel> Tags { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CodeGist, CodeGistViewModel>()
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags));
        }
    }
}