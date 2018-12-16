using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace RestApi.Handlers
{
    public class RequestsLoggingHandler : DelegatingHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            Log.Info(requestBody);

            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                var responseBody = await result.Content.ReadAsStringAsync();
                Log.Info(responseBody);
            }

            return result;
        }
    }
}