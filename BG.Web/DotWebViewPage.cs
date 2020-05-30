using BG.Core.Principal;
using BG.Web.Globalization;
using BG.Web.Helpers;
using System;
using System.Web.Mvc;

namespace BG.Web
{
	/// <summary>
	/// Custom base page for razor engine view.
	/// </summary>
	public abstract class DotWebViewPage<TModel> : WebViewPage<TModel>
	{
		/// <summary>
		/// Get the custom @Feedback helper.
		/// </summary>
		public FeedbackHelper Feedback { get; private set; }

		/// <summary>
		/// Get the custom @Globalization helper.
		/// </summary>
		public GlobalizationHelper Globalization { get; private set; }

		/// <summary>
		/// Gets the custom @User.
		/// </summary>
		public new CorePrincipal User => new CorePrincipal(base.User);

		/// <summary>
		/// Initialize page helpers.
		/// </summary>
		public override void InitHelpers()
		{
			/*
			 * Base helpers
			 */
			base.InitHelpers();

			/*
			 * Feedback helper
			 */
			Feedback = new FeedbackHelper(Html);

			/*
			 * Globalization helper
			 */
			var globalizationContext = (ViewContext.HttpContext.Items[nameof(GlobalizationContext)] as GlobalizationContext);

			if (globalizationContext == null)
				throw new ArgumentException(nameof(InitHelpers), new ArgumentNullException(nameof(globalizationContext)));

			Globalization = new GlobalizationHelper(globalizationContext.RegionCulture, globalizationContext.LanguageCulture, globalizationContext.TimeZoneInfo);
		}
	}
}
