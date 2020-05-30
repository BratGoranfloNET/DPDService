using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserTwoFactorStore<DotUser, int>
	{
		/// <summary>
		/// Get the two factor enabled status.
		/// </summary>
		public Task<bool> GetTwoFactorEnabledAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.TwoFactorEnabled;
			});
		}

		/// <summary>
		/// Set the two factor enabled status.
		/// </summary>
		public Task SetTwoFactorEnabledAsync(DotUser user, bool enabled)
		{
			return Task.Run(() =>
			{
				user.TwoFactorEnabled = enabled;
			});
		}
	}
}
