namespace BG.Services.Email
{
	/// <summary>
	/// E-Mail service interface.
	/// </summary>
	public interface IEmailService
	{
		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		void SendEmail(Email message);

		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		void SendEmail(string body, string subject, string toEmail);

		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		void SendEmail(string body, string subject, string toEmail, string toName);
	}
}
