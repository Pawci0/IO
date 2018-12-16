using System.Reflection;
using System.Web.Http.Filters;
using log4net;

namespace RestApi.Filters
{
    public class ExceptionLoggingFilter : ExceptionFilterAttribute 
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public override void OnException(HttpActionExecutedContext context)
        {
            Log.Error(context.Exception);
        }
    }
}