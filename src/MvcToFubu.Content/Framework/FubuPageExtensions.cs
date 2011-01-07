using System.Web;
using System.Web.Routing;
using FubuMVC.Core.View;

namespace MvcToFubu.Content
{
	public static class FubuPageExtensions
	{
		public static string RenderPartialFromPath(this IFubuPage page, string path)
		{
			RouteCollection routes = RouteTable.Routes;
			string originalPath = HttpContext.Current.Request.Path;
			HttpContext.Current.RewritePath(path);
			var httpContext = new HttpContextWrapper(HttpContext.Current);
			RouteData data = routes.GetRouteData(httpContext);
			IHttpHandler httpHandler = data.RouteHandler.GetHttpHandler(new RequestContext(httpContext, data));
			httpHandler.ProcessRequest(HttpContext.Current);
			httpContext.RewritePath(originalPath, false);

			return "";
		}
	}
}