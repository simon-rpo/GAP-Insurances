using Autofac;
using Autofac.Integration.WebApi;
using Insurances.Dal;
using Insurances.Model;
using Insurances.Rules;
using System.Reflection;
using System.Web.Http;

namespace Insurances.Middleware
{
    public static class AutoFactConfig
    {

        public static HttpConfiguration Configure(HttpConfiguration Configuration, Assembly ApiAssembly)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(ApiAssembly);
            builder.RegisterWebApiFilterProvider(Configuration);

            Rules(ref builder);
            DataAccessLayer(ref builder);
            External(ref builder);

            Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            return Configuration;
        }

        /// <summary>
        /// Dependency injection for Inversion of Control
        /// </summary>
        #region Private Methods
        private static void DataAccessLayer(ref ContainerBuilder builder)
        {
            builder.RegisterType<PolicyDal>().As<IPolicyDal>();
            builder.RegisterType<ClientDal>().As<IClientDal>();
            builder.RegisterType<CoveringTypeDal>().As<ICoveringTypeDal>();
        }

        private static void Rules(ref ContainerBuilder builder)
        {
            builder.RegisterType<PolicyRules>().As<IPolicyRules>();
            builder.RegisterType<ClientRules>().As<IClientRules>();
            builder.RegisterType<CoveringTypeRules>().As<ICoveringTypeRules>();
        }

        private static void External(ref ContainerBuilder builder)
        {
            builder.RegisterType<InsurancesContext>().As<InsurancesContext>();
        }

        #endregion
    }
}
