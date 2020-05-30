using BG.Core.Providers;
using System;
using System.IO;
using System.Net.Mail;
using System.Web.Hosting;

namespace BG.Web.Providers
{
	/// <summary>
	/// SMTP directory delivery provider.
	/// </summary>
	public class SmtpPickupDirectoryEmailProvider : IEmailProvider
	{
		private string _appDataFolder = null;
		private string _specifiedPickupDirectory = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public SmtpPickupDirectoryEmailProvider(EmailProviderParameters parameters)
		{
			if (parameters == null)
				throw new Exception(nameof(SmtpNetworkEmailProvider), new ArgumentNullException(nameof(parameters)));

			_appDataFolder = HostingEnvironment.MapPath("~/App_Data");
			_specifiedPickupDirectory = parameters.GetValue<string>("emailsDirectory");

			if (_appDataFolder.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(SmtpPickupDirectoryEmailProvider), new ArgumentException(nameof(_appDataFolder)));

			if (_specifiedPickupDirectory.IsNullOrWhiteSpace())
				throw new ArgumentException(nameof(SmtpPickupDirectoryEmailProvider), new ArgumentException(nameof(_specifiedPickupDirectory)));

			if (!Path.IsPathRooted(_specifiedPickupDirectory))
				_specifiedPickupDirectory = Path.Combine(_appDataFolder, _specifiedPickupDirectory.Trim('~').Trim('\\').Trim('/'));

			if (!Directory.Exists(_specifiedPickupDirectory))
				Directory.CreateDirectory(_specifiedPickupDirectory);
		}

		/// <summary>
		/// Send an e-mail message.
		/// </summary>
		public void SendEmail(MailMessage emailMessage)
		{
			using (SmtpClient smtpClient = new SmtpClient())
			{
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

				smtpClient.PickupDirectoryLocation = _specifiedPickupDirectory;

				smtpClient.Send(emailMessage);
			}
		}
	}
}
