[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KentriosiPhotoContest.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KentriosiPhotoContest.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace KentriosiPhotoContest.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Data;
    using KentriosiPhotoContest.Models;
    using KentriosiPhotosContests.Services.Contracts;
    using KentriosiPhotosContests.Services;
    using KentriosiPhotosContests.Common;
    using System.Configuration;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IKentriosiPhotoData>().To<KentriosiPhotoData>().WithConstructorArgument("context", new KentriosiPhotoContext());
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>().WithConstructorArgument("context", new KentriosiPhotoContext());

            kernel.Bind<IBaseService>().To<BaseService>().WithConstructorArgument("kentriosiPhotoData", new KentriosiPhotoData(new KentriosiPhotoContext()));
            kernel.Bind<IHomeService>().To<HomeService>().WithConstructorArgument("kentriosiPhotoData", new KentriosiPhotoData(new KentriosiPhotoContext()));
            kernel.Bind<IAccountService>().To<AccountService>().WithConstructorArgument("kentriosiPhotoData", new KentriosiPhotoData(new KentriosiPhotoContext()));
            
            kernel.Bind<IMimeTypeManager>().To<MimeTypeManager>();
            kernel.Bind<IAssemblyHelper>().To<AssemblyHelper>();
            kernel.Bind<IRandomGenerator>().To<RandomGenerator>();
            kernel.Bind<IDropboxRepository>().To<DropnetRepository>()
                .WithConstructorArgument("appKey", ConfigurationManager.AppSettings[KentriosiPhotoContest.MVC.Constants.DROPBOX_APIKEY])
                .WithConstructorArgument("appSecret", ConfigurationManager.AppSettings[KentriosiPhotoContest.MVC.Constants.DROPBOX_APPSECRET]).
                WithConstructorArgument("DropboxAccessToken", ConfigurationManager.AppSettings[KentriosiPhotoContest.MVC.Constants.DROPBOX_ACCESSTOKEN]);

            // TODO: Add here more ninject bindings
        }
    }
}
