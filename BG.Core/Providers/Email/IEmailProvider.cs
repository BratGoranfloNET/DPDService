using System.Net.Mail;

namespace BG.Core.Providers
{
	/// <summary>
	/// E-mail provider interface.
	/// </summary>
	public interface IEmailProvider
	{
		/// <summary>
		/// Sends an e-mail message.
		/// </summary>
		void SendEmail(MailMessage emailMessage);
	}
}
