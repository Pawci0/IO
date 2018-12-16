using System;
using System.Reflection;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using RestApi.Providers;

namespace RestApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Startup()
        {
            XmlConfigurator.Configure();
            
            string publicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthProvider(publicClientId),
                AuthorizeEndpointPath = new PathString("/api/User"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                AllowInsecureHttp = true
            };
        }
    }
}