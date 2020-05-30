using System;
using System.Web;

namespace BG.Web.UI.Extensions
{
	/// <summary>
	/// Partial HttpContext extensions.
	/// </summary>
	public static partial class HttpContextExtensions
	{
		/// <summary>
		/// Set cookie data.
		/// </summary>
		public static void SetCookie(this HttpContextBase @this, string cookieName, string cookieValue, DateTime? expirationDate = null)
		{
			var requestCookies = @this.Request.Cookies;
			var responseCookies = @this.Response.Cookies;

			if (expirationDate == null)
				expirationDate = DateTime.UtcNow.AddYears(1);

			var httpCookie = @this.GetCookie(cookieName);

			if (httpCookie == null)
				httpCookie = new HttpCookie(cookieName);

			httpCookie.Value = cookieValue;
			httpCookie.Expires = expirationDate.Value;

			responseCookies.Add(httpCookie);
		}
	}
}
