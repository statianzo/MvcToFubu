using System.Threading;
using MvcToFubu.Content.Models;

namespace MvcToFubu.Content.Controllers
{
	public class ShopController
	{
		public ShopModuleViewModel Module (ShopModuleInputModel model)
		{
			Thread.Sleep(3000);
			return new ShopModuleViewModel {Campaign = model.Name.ToUpper()};
		}

		public ShopModuleViewModel Module ()
		{
			Thread.Sleep(3000);
			return new ShopModuleViewModel {Campaign = "Retail"};
		}
	}
}