using System.IO;
using System.Text;
using System.Web;

namespace MvcToFubu.Framework
{
    public class StringOutputContext : HttpContextWrapper
    {
        public StringBuilder StringBuilder { get; set; }

        public StringOutputContext(HttpContext httpContext) : base(httpContext)
        {
        }

        public override void SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior sessionStateBehavior)
        {
            StringBuilder = new StringBuilder();
            var writer = new StringWriter(StringBuilder);
            Response.Output = writer;
        }
    }
}