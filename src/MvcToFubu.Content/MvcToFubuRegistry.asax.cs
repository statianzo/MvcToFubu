using MvcToFubu.Content.Controllers;
using Spark.Web.FubuMVC;
using Spark.Web.FubuMVC.Extensions;

namespace MvcToFubu.Content
{
	public class MvcToFubuRegistry:SparkFubuRegistry
	{
		private readonly SparkViewFactory _factory;

		public MvcToFubuRegistry(SparkViewFactory factory) : base(factory)
		{
			_factory = factory;

			Applies.ToThisAssembly();

			Actions
				.IncludeTypesNamed(x => x.EndsWith("Controller"));

			SparkPolicies
				.AttachViewsBy(call =>
				               call.HandlerType.Name.EndsWith("Controller"),
				               call => call.HandlerType.Name.RemoveSuffix("Controller"),
				               call => call.Method.Name);

			Routes
				.IgnoreMethodsNamed("Index");

			HomeIs<HomeController>(c => c.Home());
		}
	}
}