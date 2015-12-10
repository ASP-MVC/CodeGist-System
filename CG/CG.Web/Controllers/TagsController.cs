using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CG.Data.UoW;
using CG.Web.Models.ViewModels;

namespace CG.Web.Controllers
{
    public class TagsController : BaseController
    {
        public TagsController(ICGData data) : base(data)
        {
        }

        public ActionResult All()
        {
            var tags =
                this.Data.Tags.All()
                    .OrderByDescending(t => t.CreatedOn)
                    .ProjectTo<TagViewModel>()
                    .ToList();

            return this.View(tags);
        }
    }
}