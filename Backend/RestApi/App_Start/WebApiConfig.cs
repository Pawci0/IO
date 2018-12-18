using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using RestApi.Filters;
using RestApi.Handlers;

namespace RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Filters.Add(new AuthorizeAttribute());
            config.Filters.Add(new UserExceptionFilter());
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new ExceptionLoggingFilter());
            
            config.MessageHandlers.Add(new RequestsLoggingHandler());
            
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
