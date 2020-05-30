using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserLockoutStore<DotUser, int>
	{
		/// <summary>
		/// Gets the flag indicating if the lockout system is enabled.
		/// </summary>
		public Task<bool> GetLockoutEnabledAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.LockoutEnabled;
			});
		}

		/// <summary>
		/// Get the number of failed access attempts from the user.
		/// </summary>
		public Task<int> GetAccessFailedCountAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.AccessFailedCount;
			});
		}

		/// <summary>
		/// Get the date where the user lockout ends.
		/// </summary>
		public Task<DateTimeOffset> GetLockoutEndDateAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				if (user.LockoutEndDateUtc.HasValue)
					return new DateTimeOffset(user.LockoutEndDateUtc.Value);

				return DateTimeOffset.UtcNow;
			});
		}

		/// <summary>
		/// Increment failed access attempts.
		/// </summary>
		public Task<int> IncrementAccessFailedCountAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				if (user.LockoutEnabled)
					return user.AccessFailedCount++;

				return 0;
			});
		}

		/// <summary>
		/// Reset failed access attempts.
		/// </summary>
		public Task ResetAccessFailedCountAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				return user.AccessFailedCount = 0;
			});
		}

		/// <summary>
		/// Set the lockout enabled flag.
		/// </summary>
		public Task SetLockoutEnabledAsync(DotUser user, bool enabled)
		{
			return Task.Run(() =>
			{
				return user.LockoutEnabled = enabled;
			});
		}

		/// <summary>
		/// Set the lockout end date.
		/// </summary>
		public Task SetLockoutEndDateAsync(DotUser user, DateTimeOffset lockoutEnd)
		{
			return Task.Run(() =>
			{
				return user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
			});
		}
	}
}