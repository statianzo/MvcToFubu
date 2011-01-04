using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcToFubu
{
	public class Global : HttpApplication
	{
		public void Application_Start()
		{
			RouteCollection routes = RouteTable.Routes;

			routes.MapRoute("default",
			                "{controller}/{action}",
			                new {controller = "Home", action = "Index"});
		}
	}
}