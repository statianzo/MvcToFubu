using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spark.Web.Mvc;

namespace MvcToFubu
{
	public class Global : HttpApplication
	{
		public void Application_Start()
		{
			IViewEngine engine = new SparkViewFactory();
			ViewEngines.Engines.Add(engine);
			RouteCollection routes = RouteTable.Routes;

			routes.MapRoute("default",
			                "{controller}/{action}",
			                new {controller = "Home", action = "Index"});
		}
	}
}