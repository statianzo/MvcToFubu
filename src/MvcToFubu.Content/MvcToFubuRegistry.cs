using FubuMVC.Core.UI.Configuration;
using MvcToFubu.Content.Controllers;
using MvcToFubu.Content.Models;
using Spark.Web.FubuMVC;
using Spark.Web.FubuMVC.Extensions;

namespace MvcToFubu.Content
{
	public class MvcToFubuRegistry : SparkFubuRegistry
	{
		private readonly SparkViewFactory _factory;

		public MvcToFubuRegistry(SparkViewFactory factory) : base(factory)
		{
			_factory = factory;

			Applies.ToThisAssembly();

			IncludeDiagnostics(true);

			Actions
				.IncludeTypesNamed(x => x.EndsWith("Controller"));

			SparkPolicies
				.AttachViewsBy(call =>
				               call.HandlerType.Name.EndsWith("Controller"),
				               call => call.HandlerType.Name.RemoveSuffix("Controller"),
				               call => call.Method.Name);

			Routes
				.IgnoreMethodsNamed("Index")
				.IgnoreNamespaceText("MvcToFubu.Content.Controllers")
				.ForInputTypesOf<IIdentifiableName>(c => c.RouteInputFor(i => i.Name));

			HtmlConvention<DefaultHtmlConventions>();

			HomeIs<HomeController>(c => c.Home());
		}
	}
}