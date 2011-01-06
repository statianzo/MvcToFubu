using System.Web;
using System.Web.Routing;

namespace MvcToFubu.Framework
{
    public class RouteToHandler : UrlRoutingHandler
    {
        public IHttpHandler HttpHandler { get; private set; }

        public void PublicProcessRequest(HttpContextBase httpContext)
        {
            ProcessRequest(httpContext);
        }

        protected override void VerifyAndProcessRequest(IHttpHandler httpHandler, HttpContextBase httpContext)
        {
            HttpHandler = httpHandler;
        }
    }
}