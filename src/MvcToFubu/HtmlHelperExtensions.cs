using System.Web;
using System.Web.Mvc;
using MvcToFubu.Framework;

namespace MvcToFubu
{
    public static class HtmlHelperExtensions
    {
        public static string RenderPartialFromPath(this HtmlHelper helper, string path)
        {
            var httpContext = HttpContext.Current;
			string originalPath = httpContext.Request.Path;
			httpContext.RewritePath(path, false);
            var handler = new RouteToHandler();
            var wrapper = new StringOutputContext(httpContext);
            handler.PublicProcessRequest(wrapper);
            IHttpHandler httpHandler = handler.HttpHandler;
			httpHandler.ProcessRequest(httpContext);
			httpContext.RewritePath(originalPath, false);

            return wrapper.StringBuilder.ToString();
        }
    }
}