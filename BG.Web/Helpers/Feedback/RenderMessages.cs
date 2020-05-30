using System.Web.Mvc;

namespace BG.Web.Helpers
{
	/// <summary>
	/// Partial @Feedback helper.
	/// </summary>
	public partial class FeedbackHelper
	{
		/// <summary>
		/// Render existing feedback messages.
		/// </summary>
		public MvcHtmlString RenderMessages()
		{
			var wrapperDiv = new TagBuilder("div");

			wrapperDiv.AddCssClass("feedback-messages");

			foreach (var message in _feedbackContext.Messages)
			{
				var messageDiv = new TagBuilder("div");

				messageDiv.MergeAttribute("data-type", message.Type.ToLowerCaseString());
				messageDiv.MergeAttribute("data-content", message.Content);
				messageDiv.MergeAttribute("data-title", message.Title);

				wrapperDiv.InnerHtml += messageDiv;
			}

			return MvcHtmlString.Create(wrapperDiv.ToString());
		}
	}
}
