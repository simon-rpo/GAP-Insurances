using Insurances.Middleware;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Insurances.Api
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            //CORS
            EnableCorsAttribute cors = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*");
            config.EnableCors(cors);
            // Middleware Config...
            config = AutoFactConfig.Configure(config, Assembly.GetExecutingAssembly());
            AutoMapperConfig.Configure();
            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
