namespace MvcToFubu.Content.Models
{
	public class ShopModuleViewModel
	{
		public string Campaign { get; set; }
	}
	public class ShopModuleInputModel:IIdentifiableName
	{
		public string Name { get; set; }
	}

	public interface IIdentifiableName
	{
		string Name { get; set; }
	}
}