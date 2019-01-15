using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin;

namespace RestApi.Extensions
{
    public static class SessionContext
    {
        public static int TryGetUserId()
        {
            IOwinContext ctx = HttpContext.Current.GetOwinContext();
            Claim claim = ctx?.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserID");

            if (claim != null)
            {
                bool isParsed = int.TryParse(claim.Value, out int id);
                if (isParsed)
                {
                    return id;
                }
            }

            throw new AuthenticationException("User is not authenticated");
        }
    }
}