using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HomeworkPaul.Areas.Registration.Repository;
using HomeworkPaul.Common;
using Ninject;
using Ninject.Web.Common.WebHost;

namespace HomeworkPaul
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(StandardKernel kernel)
        {
            var registrationConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            kernel.Bind<IRegistrationRepository>().To<RegistrationRepository>().WithConstructorArgument("connectionString", registrationConnectionString);
            kernel.Bind<IPasswordHasher>().To<PasswordHasher>();
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
