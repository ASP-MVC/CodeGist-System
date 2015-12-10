using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CG.Data.UoW;
using CG.Web.Models.ViewModels;

namespace CG.Web.Controllers
{
    using System;

    using AutoMapper;

    using CG.Models;
    using CG.Web.Models.BindingModel;

    [Authorize]
    public class TagsController : BaseController
    {
        public TagsController(ICGData data) : base(data)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult All()
        {
            var tags =
                this.Data.Tags.All()
                    .OrderByDescending(t => t.CreatedOn)
                    .ProjectTo<TagViewModel>()
                    .ToList();

            return this.View(tags);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetTagCodeGists(int id)
        {
            var tag = this.FindTagById(id);
            if (tag == null)
            {
                return this.HttpNotFound("404 Not found");
            }

            var tagCodeGists =
                tag.CodeGists.AsQueryable()
                   .ProjectTo<CodeGistViewModel>()
                   .ToList();
            return this.View(tagCodeGists);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(TagBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var tag = Mapper.Map<TagBindingModel, Tag>(model);
                this.Data.Tags.Add(tag);
                this.Data.SaveChanges();
            }
            return this.View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var tag = this.FindTagById(id);
            if (tag == null)
            {
                return this.HttpNotFound("404 Not found");
            }

            tag.IsDeleted = true;
            tag.DeletedOn = DateTime.Now;
            this.Data.Tags.Update(tag);
            this.Data.SaveChanges();
            return this.RedirectToAction("All");
        }

        private Tag FindTagById(int tagId)
        {
            return this.Data.Tags.All().FirstOrDefault(t => t.Id == tagId);
        }
    }
}