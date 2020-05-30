using Microsoft.AspNet.Identity;
using BG.Services.Email;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// ASP.Net identity email service.
	/// </summary>
	public class IdentityEmailService : IIdentityMessageService
	{
		private IEmailService _emailService = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public IdentityEmailService(IEmailService emailService)
		{
			_emailService = emailService;
		}

		/// <summary>
		/// Send an identity e-mail message.
		/// </summary>
		public Task SendAsync(IdentityMessage message)
		{
			return Task.Run(() => {
				_emailService.SendEmail(message.Body, message.Subject, message.Destination);
			});
		}
	}
}
