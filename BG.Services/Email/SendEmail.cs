using System.Net.Mail;

namespace BG.Services.Email
{
	/// <summary>
	/// Partial e-mail services implementation.
	/// </summary>
	public partial class EmailService
	{
		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		public void SendEmail(Email message)
		{
			_emailProvider.SendEmail(message);
		}

		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		public void SendEmail(string body, string subject, string toEmailAddress)
		{
			SendEmail(body, subject, toEmailAddress, null);
		}

		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		public void SendEmail(string body, string subject, string toEmailAddress, string toDisplayName)
		{
			using (var message = new Email())
			{
				// Content
				message.SubjectEncoding = System.Text.Encoding.UTF8;
				message.BodyEncoding = System.Text.Encoding.UTF8;
				message.IsBodyHtml = true;
				message.Subject = subject;
				message.Body = body;

				// From
				message.Sender = new MailAddress(_emailServiceSettings.SenderEmailAddress, _emailServiceSettings.SenderDisplayName);
				message.From = message.Sender;

				// To
				if (string.IsNullOrWhiteSpace(toDisplayName))
					message.To.Add(toEmailAddress);
				else
					message.To.Add(new MailAddress(toEmailAddress, toDisplayName));

				SendEmail(message);
			}
		}
	}
}
