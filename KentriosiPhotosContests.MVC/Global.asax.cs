namespace KentriosiPhotoContest.MVC
{
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Data;
    using Data.Migrations;
    using KentriosiPhotoContest.MVC.Infrastructure.Mapping;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KentriosiPhotoContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<KentriosiPhotoContext>());
            var configuration = new KentriosiPhotoContest.Data.Migrations.Configuration();
            configuration.ExposedSeed();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Execute();
        }
    }
}
