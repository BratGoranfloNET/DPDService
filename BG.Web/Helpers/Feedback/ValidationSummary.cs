using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BG.Web.Helpers
{
	/// <summary>
	/// Partial @Feedback helper.
	/// </summary>
	public partial class FeedbackHelper
	{
		/// <summary>
		/// Supported summary visualization modes.
		/// </summary>
		public enum VisualizationMode : byte
		{
			/// <summary>
			/// #0 - Bootstrap alerts.
			/// </summary>
			Alert = 0,

			/// <summary>
			/// #1 - Form panels.
			/// </summary>
			Panel = 1
		}

		/// <summary>
		/// Renders a validation summary for server results.
		/// </summary>
		public MvcHtmlString ValidationSummary(VisualizationMode visualizationMode)
		{
			if (visualizationMode == VisualizationMode.Alert)
				return _htmlHelper.Partial("ValidationSummaryAlerts");

			return _htmlHelper.Partial("ValidationSummaryPanels");
		}
	}
}
