using BG.Core.Providers;
using System;
using System.Net;
using System.Net.Mail;

namespace BG.Web.Providers
{
	/// <summary>
	/// SMTP network delivery provider.
	/// </summary>
	public class SmtpNetworkEmailProvider : IEmailProvider
	{
		private int _port = 0;
		private string _host = null;
		private string _userName = null;
		private string _password = null;
		private bool _enableSsl = false;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public SmtpNetworkEmailProvider(EmailProviderParameters parameters)
		{
			if (parameters == null)
				throw new Exception(nameof(SmtpNetworkEmailProvider), new ArgumentNullException(nameof(parameters)));

			_port = parameters.GetValue<int>("port");
			_host = parameters.GetValue<string>("host");

			_userName = parameters.GetValue<string>("host");
			_password = parameters.GetValue<string>("host");

			_enableSsl = parameters.GetValue<bool>("enableSsl");
		}

		/// <summary>
		/// Send an e-mail message.
		/// </summary>
		public void SendEmail(MailMessage emailMessage)
		{
			using (SmtpClient smtpClient = new SmtpClient(_host, _port))
			{
				smtpClient.EnableSsl = _enableSsl;

				smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

				if (!_userName.IsNullOrWhiteSpace())
					smtpClient.Credentials = new NetworkCredential(_userName, _password);

				smtpClient.Send(emailMessage);
			}
		}
	}
}
