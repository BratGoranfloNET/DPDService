using System.Collections.Generic;

namespace BG.Web.Feedback
{
	/// <summary>
	/// Feedback messages context manager.
	/// </summary>
	public class FeedbackContext
	{
		private List<FeedbackMessage> _messages = new List<FeedbackMessage>();

		/// <summary>
		/// Get current messages.
		/// </summary>
		public List<FeedbackMessage> Messages => _messages;

		/// <summary>
		/// Adds a message instance.
		/// </summary>
		private void AddMessage(FeedbackMessage message)
		{
			_messages.Add(message);
		}

		/// <summary>
		/// Add a new message.
		/// </summary>
		public void AddMessage(FeedbackMessageType type, string content, string title = null)
		{
			var message = new FeedbackMessage(type, content, title);

			AddMessage(message);
		}

		/// <summary>
		/// Add a new message.
		/// </summary>
		public void AddMessageError(string content, string title = null)
		{
			var message = new FeedbackMessage(FeedbackMessageType.Error, content, title);

			AddMessage(message);
		}

		/// <summary>
		/// Add a new message.
		/// </summary>
		public void AddMessageInfo(string content, string title = null)
		{
			var message = new FeedbackMessage(FeedbackMessageType.Info, content, title);

			AddMessage(message);
		}

		/// <summary>
		/// Add a new message.
		/// </summary>
		public void AddMessageSuccess(string content, string title = null)
		{
			var message = new FeedbackMessage(FeedbackMessageType.Success, content, title);

			AddMessage(message);
		}

		/// <summary>
		/// Add a new message.
		/// </summary>
		public void AddMessageWarning(string content, string title = null)
		{
			var message = new FeedbackMessage(FeedbackMessageType.Warning, content, title);

			AddMessage(message);
		}
	}
}
