using System.Linq;
using System.Security.Claims;
using Microsoft.Owin;

namespace RestApi.Extensions
{
    public static class OwinContextExtensions
    {
        public static int? GetUserId(this IOwinContext ctx)
        {
            Claim claim = ctx.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserID");
            
            if (claim != null)
            {
                int id;
                bool isParsed = int.TryParse(claim.Value, out id);
                if (isParsed)
                {
                    return id;
                }
            }
            
            return null;
        }
    }
}