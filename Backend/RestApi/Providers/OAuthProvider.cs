using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using User;

namespace RestApi.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public OAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException(nameof(publicClientId));
            }

            _publicClientId = publicClientId;
        }
        
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                UserService userService = new UserService();
                
                string username = context.UserName;
                string password = userService.GetHashedPassword(context.UserName, context.Password);
                UserDto userDto = new UserDto
                {
                    Username = username,
                    Password = password
                };

                SecurityService securityService = new SecurityService();
                if (securityService.AuthenticateUser(userDto))
                {
                    
                    UserDto user = userService.GetUser(username);

                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Username),
                        new Claim("UserID", user.Id.ToString())
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties()));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            
            return Task.FromResult<object>(null);
        }
    }
}