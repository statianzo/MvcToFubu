using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MvcToFubu.Controllers
{
	public class HomeController:Controller
	{
		public ActionResult Index()
		{
			Session["hello"] = "hi";
			Response.Cookies.Add(new HttpCookie("sec", "cook"));
			return View();
		}

		public ActionResult News()
		{
		    var data = new JavaScriptSerializer().Serialize(RouteData.Values);
            Response.Output.Write(data);
			return View();
		}
	}
}