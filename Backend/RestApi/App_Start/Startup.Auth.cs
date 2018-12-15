using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using RestApi.Providers;

namespace RestApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
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