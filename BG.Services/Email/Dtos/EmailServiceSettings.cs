using System;

namespace BG.Services.Email
{
	/// <summary>
	/// Email service settings implementation.
	/// </summary>
	public class EmailServiceSettings
	{
		/// <summary>
		/// Gets the sender display name.
		/// </summary>
		public string SenderDisplayName { get; private set; }

		/// <summary>
		/// Gets the sender e-mail address.
		/// </summary>
		public string SenderEmailAddress { get; private set; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public EmailServiceSettings(string senderDisplayName, string senderEmailAddress)
		{
			if (string.IsNullOrWhiteSpace(senderDisplayName))
				throw new Exception(nameof(EmailServiceSettings), new ArgumentNullException(nameof(senderDisplayName)));

			if (string.IsNullOrWhiteSpace(senderEmailAddress))
				throw new Exception(nameof(EmailServiceSettings), new ArgumentNullException(nameof(senderEmailAddress)));

			SenderDisplayName = senderDisplayName;
			SenderEmailAddress = senderEmailAddress;
		}
	}
}
