using Microsoft.AspNet.Identity;
using Omu.ValueInjecter;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserEmailStore<DotUser, int>
	{
		/// <summary>
		/// Get an user by e-mail.
		/// </summary>
		public Task<DotUser> FindByEmailAsync(string email)
		{
			return Task.Run(() =>
			{
				var user = _usersRepository.GetByEmail(email);

				if (user == null)
					return null;

				return Mapper.Map<DotUser>(user);
			});
		}

		/// <summary>
		/// Get the user e-mail address.
		/// </summary>
		public Task<string> GetEmailAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.Email;
			});
		}

		/// <summary>
		/// Get the status indicating if the user confirmed the e-mail.
		/// </summary>
		public Task<bool> GetEmailConfirmedAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.EmailConfirmed;
			});
		}

		/// <summary>
		/// Set the user e-mail.
		/// </summary>
		public Task SetEmailAsync(DotUser user, string email)
		{
			return Task.Run(() =>
			{
				user.Email = email;
			});
		}

		/// <summary>
		/// Set the user confirmed e-mail.
		/// </summary>
		public Task SetEmailConfirmedAsync(DotUser user, bool confirmed)
		{
			return Task.Run(() =>
			{
				user.EmailConfirmed = confirmed;
			});
		}
	}
}