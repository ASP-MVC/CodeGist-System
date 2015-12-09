using System.Web.Mvc;

namespace CG.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Routing;

    using CG.Data.UoW;
    using CG.Models;

    public abstract class BaseController : Controller
    {
        protected BaseController(ICGData data)
        {
            this.Data = data;
        }

        protected ICGData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                this.UserProfile =
                this.Data.Users.All()
                .FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}