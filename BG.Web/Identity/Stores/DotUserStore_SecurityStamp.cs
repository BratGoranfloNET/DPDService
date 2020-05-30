using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserSecurityStampStore<DotUser, int>
	{
		/// <summary>
		/// Get the current section security stamp.
		/// </summary>
		public Task<string> GetSecurityStampAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.SecurityStamp.EnsureNotNull();
			});
		}

		/// <summary>
		/// Set a new section security stamp.
		/// </summary>
		public Task SetSecurityStampAsync(DotUser user, string stamp)
		{
			return Task.Run(() =>
			{
				user.SecurityStamp = stamp;
			});
		}
	}
}