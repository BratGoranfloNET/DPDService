using System;

namespace BG.Web.Feedback
{
	/// <summary>
	/// Represents a feedback message.
	/// </summary>
	public class FeedbackMessage
	{
		/// <summary>
		/// Gets the type.
		/// </summary>
		public FeedbackMessageType Type { get; private set; }

		/// <summary>
		/// Gets the content.
		/// </summary>
		public string Content { get; private set; }

		/// <summary>
		/// Gets the title.
		/// </summary>
		public string Title { get; private set; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public FeedbackMessage(FeedbackMessageType type, string content, string title)
		{
			if (string.IsNullOrWhiteSpace(content))
				throw new ArgumentException(nameof(content));

			if (string.IsNullOrWhiteSpace(title))
				title = type.GetDisplayName();

			Type = type;
			Content = content;
			Title = title;
		}
	}
}
