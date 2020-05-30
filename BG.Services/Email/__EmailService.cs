using BG.Core.Providers;
using System;

namespace BG.Services.Email
{
	/// <summary>
	/// Partial e-mail services implementation.
	/// </summary>
	public partial class EmailService : IEmailService
	{
		private IEmailProvider _emailProvider = null;
		private EmailServiceSettings _emailServiceSettings = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public EmailService(IEmailProvider emailProvider, EmailServiceSettings emailServiceSettings)
		{
			_emailProvider = emailProvider;
			_emailServiceSettings = emailServiceSettings;

			if (_emailProvider == null)
				throw new ServiceException(nameof(EmailService), new ArgumentNullException(nameof(_emailProvider)));

			if (_emailServiceSettings == null)
				throw new ServiceException(nameof(EmailService), new ArgumentNullException(nameof(_emailServiceSettings)));
		}
	}
}
