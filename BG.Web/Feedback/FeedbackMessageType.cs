using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.Feedback
{
	/// <summary>
	/// Represent the different types of messages that can be presented to the user.
	/// </summary>
	public enum FeedbackMessageType : byte
	{
		/// <summary>
		/// #0 - Error color.
		/// </summary>
		[Display(Name = "FeedbackMessageTypeError", ResourceType = (typeof(BG.Core.Resources.WebUIResources)))]
		Error = 0,

		/// <summary>
		/// #1 - Information color.
		/// </summary>
		[Display(Name = "FeedbackMessageTypeInfo", ResourceType = (typeof(WebUIResources)))]
		Info = 1,

		/// <summary>
		/// #2 - Success color.
		/// </summary>
		[Display(Name = "FeedbackMessageTypeSuccess", ResourceType = (typeof(WebUIResources)))]
		Success = 2,

		/// <summary>
		/// #3 - Warning color.
		/// </summary>
		[Display(Name = "FeedbackMessageTypeWarning", ResourceType = (typeof(WebUIResources)))]
		Warning = 3
	}
}
