using BG.Web.Feedback;
using System.Web.Mvc;

namespace BG.Web.Helpers
{
	/// <summary>
	/// Partial @Feedback helper.
	/// </summary>
	public partial class FeedbackHelper
	{
		private HtmlHelper _htmlHelper = null;
		private FeedbackContext _feedbackContext = new FeedbackContext();

		/// <summary>
		/// Constructor method.
		/// </summary>
		public FeedbackHelper(HtmlHelper htmlHelper)
		{
			_htmlHelper = htmlHelper;
			_feedbackContext = _htmlHelper?.ViewContext?.TempData[nameof(FeedbackContext)] as FeedbackContext ?? new FeedbackContext();
		}
	}
}
