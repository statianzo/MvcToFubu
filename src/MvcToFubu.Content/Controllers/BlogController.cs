using System.Web;
using MvcToFubu.Content.Models;

namespace MvcToFubu.Content.Controllers
{
	public class BlogController
	{
		public BlogHeadlinesViewModel Headlines()
		{
			var cookie = HttpContext.Current.Request.Cookies["sec"];
			return new BlogHeadlinesViewModel();
		}
	}
}