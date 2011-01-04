using Spark.Web.FubuMVC;
using Spark.Web.FubuMVC.Registration;
using StructureMap;

namespace MvcToFubu.Content
{
	public class Global : SparkStructureMapApplication
	{
		public override SparkFubuRegistry GetMyRegistry()
		{
			return ObjectFactory.GetInstance<MvcToFubuRegistry>();
		}
	}
}