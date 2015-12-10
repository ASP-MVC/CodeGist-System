namespace CG.Web
{
    using System.Data.Entity;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using CG.Data;
    using CG.Data.Migrations;

    using System.Collections.Generic;
    using System.Reflection;
    using CG.Infrastructure.Mappings;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            this.LoadAutoMapper();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CGDbContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void LoadAutoMapper()
        {
            var autoMapperConfig = new AutoMapperConfig(new List<Assembly>() { Assembly.GetExecutingAssembly() });
            autoMapperConfig.Execute();
        }
    }
}