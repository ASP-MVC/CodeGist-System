using AutoMapper;
using CG.Infrastructure.Mappings;
using CG.Models;

namespace CG.Web.Models.ViewModels
{
    public class TagViewModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, TagViewModel>()
                .ReverseMap();
        }
    }
}