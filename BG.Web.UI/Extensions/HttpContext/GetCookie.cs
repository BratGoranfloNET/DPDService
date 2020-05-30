using System.Web;

namespace BG.Web.UI.Extensions
{
	/// <summary>
	/// Partial HttpContext extensions.
	/// </summary>
	public static partial class HttpContextExtensions
	{
		/// <summary>
		/// Get cookie data.
		/// </summary>
		public static HttpCookie GetCookie(this HttpContextBase @this, string cookieName)
		{
			var requestCookies = @this.Request.Cookies;

			return requestCookies.Get(cookieName);
		}
	}
}
