using System.Web.Mvc;

namespace MvcToFubu.Controllers
{
	public class HomeController:Controller
	{
		public ActionResult Index()
		{
			return Content("Welcome Home");
		}
	}
}