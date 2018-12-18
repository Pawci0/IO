using System.Linq;
using System.Security.Claims;
using Microsoft.Owin;

namespace RestApi.Extensions
{
    public static class SessionContext
    {
        public static int? GetUserId(this IOwinContext ctx)
        {
            Claim claim = ctx.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserID");
            
            if (claim != null)
            {
                bool isParsed = int.TryParse(claim.Value, out int id);
                if (isParsed)
                {
                    return id;
                }
            }
            
            return null;
        }
    }
}