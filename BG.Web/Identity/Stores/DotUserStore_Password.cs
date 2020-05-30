using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserPasswordStore<DotUser, int>
	{
		/// <summary>
		/// Get the password hash.
		/// </summary>
		public Task<string> GetPasswordHashAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.PasswordHash;
			});
		}

		/// <summary>
		/// Check if the user has a password hash.
		/// </summary>
		public Task<bool> HasPasswordAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return !user.PasswordHash.IsNullOrWhiteSpace();
			});
		}

		/// <summary>
		/// Set the user password hash.
		/// </summary>
		public Task SetPasswordHashAsync(DotUser user, string passwordHash)
		{
			return Task.Run(() =>
			{
				user.PasswordHash = passwordHash;
			});
		}
	}
}