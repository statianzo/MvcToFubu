using MvcToFubu.Content.Models;

namespace MvcToFubu.Content.Controllers
{
	public class BlogController
	{
		public BlogHeadlinesViewModel Headlines()
		{
			return new BlogHeadlinesViewModel();
		}
	}
}