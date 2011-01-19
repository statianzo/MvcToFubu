using System;
using System.Web.Security;
using ManagedFusion.Rewriter;
using ManagedFusion.Rewriter.Conditions;

namespace MvcToFubu.Framework
{
	public class AuthenticationCondition:ICondition
	{
		
		public bool Evaluate(ConditionContext context)
		{
			string test = Test.GetValue(context);
			return Pattern.IsMatch(test);
		}

		public void Init(Pattern pattern, IConditionTestValue test, IConditionFlagProcessor flags)
		{
			Pattern = pattern;
			Test = new AuthenticationTestValue(test);
			Flags = flags ?? new ConditionFlagProcessor();
		}

		public Pattern Pattern
		{
			get; private set;
		}

		public IConditionTestValue Test
		{
			get; private set;
		}

		public IConditionFlagProcessor Flags
		{
			get; private set;
		}

		public class AuthenticationTestValue :IConditionTestValue
		{
			public AuthenticationTestValue(IConditionTestValue testValue)
			{
				Init(testValue.Test);
			}
			public string GetValue(ConditionContext context)
			{
				var cookie = context.HttpContext.Request.Cookies[".ASPXFORMSAUTH"];
				if(cookie == null)
					return "";
				var user = FormsAuthentication.Decrypt(cookie.Value);
				if(Test.Contains("%{AUTH_USER}") && user != null && !user.Expired)
				{
					return user.Name;
				}
				return "";
			}

			public void Init(string test)
			{
				Test = test;
			}

			public string Test
			{
				get; set;
			}
		}
	}
}