using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using User.Validation;

namespace RestApi.Filters
{
    public class UserExceptionFilter : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is UserException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    context.Exception);
            }
        }
    }
}