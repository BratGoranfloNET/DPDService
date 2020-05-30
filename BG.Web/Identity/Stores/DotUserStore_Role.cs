using Microsoft.AspNet.Identity;
using BG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserRoleStore<DotUser, int>
	{
		/// <summary>
		/// Get user roles.
		/// </summary>
		public Task<IList<string>> GetRolesAsync(DotUser user)
		{
			return Task.Run<IList<string>>(() =>
			{
				return user.Roles.Select(userRole => userRole.Role.ToString()).ToList();
			});
		}

		/// <summary>
		/// Associate a role to an user.
		/// </summary>
		public Task AddToRoleAsync(DotUser user, string roleId)
		{
			return Task.Run(() =>
			{
				var userRole = new UserRole()
				{
					UserId = user.Id,
					Role = roleId.ChangeType<Role>()
				};

				user.Roles.Add(userRole);
			});
		}

		/// <summary>
		/// Verify if the user has the given role.
		/// </summary>
		public Task<bool> IsInRoleAsync(DotUser user, string roleId)
		{
			return Task.Run(() =>
			{
				return user.Roles.Any(r => r.Role.ToString().Equals(roleId));
			});
		}

		/// <summary>
		/// Remove role from user.
		/// </summary>
		public Task RemoveFromRoleAsync(DotUser user, string roleId)
		{
			return Task.Run(() =>
			{
				var role = user.Roles.Where(r => r.Role.ToString().Equals(roleId)).SingleOrDefault();

				if (role == null)
					throw new ArgumentException(nameof(RemoveFromRoleAsync), new ArgumentNullException(nameof(role)));

				user.Roles.Remove(role);
			});
		}
	}
}