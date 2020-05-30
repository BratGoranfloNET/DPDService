using System.Web.Mvc;

namespace BG.Web.UI.Extensions
{
	/// <summary>
	/// Partial @Url extensions.
	/// </summary>
	public static partial class UrlHelperExtensions
	{
		/// <summary>
		/// Checks the current url for a matching pattern
		/// <para>This method will be reviewed and possibly removed on version 3</para>
		/// </summary>
		public static string MatchMenuAction(this UrlHelper @this, string menuActionUrl, string outputClasses)
		{
			var rawUrl = @this.RequestContext.HttpContext.Request.RawUrl;

			if (!menuActionUrl.IsNullOrEmpty() && rawUrl.Contains(menuActionUrl))
				return outputClasses;

			return string.Empty;
		}
	}
}
