namespace CG.Web.Models.ViewModels
{
    using CG.Infrastructure.Mappings;
    using CG.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName  { get; set; }

        public string Email { get; set; }
    }
}