using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KentriosiPhotoContest.MVC.Startup))]
namespace KentriosiPhotoContest.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
