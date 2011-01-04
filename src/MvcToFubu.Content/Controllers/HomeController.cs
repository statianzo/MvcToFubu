using MvcToFubu.Content.Models;

namespace MvcToFubu.Content.Controllers
{
	public class HomeController
	{
		public HomeViewModel Home()
		{
			return new HomeViewModel();
		}
	}
}