using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using User.Validation;

namespace RestApi.Filters
{
    public class UserValidationFilter : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is UserValidationException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    context.Exception);
            }
        }
    }
}