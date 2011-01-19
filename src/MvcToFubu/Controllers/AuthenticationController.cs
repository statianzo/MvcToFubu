using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcToFubu.Controllers
{

	public class AuthenticationController : Controller
	{
		private IDictionary<string, string> _accounts = new Dictionary<string, string>
		{
			{"admin", "admin"},
			{"user", "password"}
		};
		public ActionResult Login()
		{
			return View();
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return Redirect(Url.Action("Index", "Home"));
		}

		public ActionResult LoginSubmit(string username, string password)
		{
			var redirectUrl = Url.Action("Login");
			var valid =
				_accounts.Any(a => a.Key.Equals(username, StringComparison.OrdinalIgnoreCase) && a.Value == password);
			if (valid)
			{
				FormsAuthentication.SignOut();
				FormsAuthentication.SetAuthCookie(username, true);
				redirectUrl = Url.Action("Index", "Home");
			}

			return Redirect(redirectUrl);
		}
	}
}