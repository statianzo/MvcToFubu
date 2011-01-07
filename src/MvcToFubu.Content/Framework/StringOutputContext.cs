using System.IO;
using System.Text;
using System.Web;

namespace MvcToFubu.Content.Framework
{
    public class StringOutputContext : HttpContextWrapper
    {
        public StringBuilder StringBuilder { get; set; }

        public StringOutputContext(HttpContext httpContext) : base(httpContext)
        {
            StringBuilder = new StringBuilder();
            var writer = new StringWriter(StringBuilder);
            Response.Output = writer;
        }

        public override void SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior sessionStateBehavior)
        {
        }
    }
}