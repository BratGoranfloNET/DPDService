using Microsoft.AspNet.Identity;
using Omu.ValueInjecter;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserClaimStore<DotUser, int>
	{
		/// <summary>
		/// Add a new claim to the current user.
		/// </summary>
		public Task AddClaimAsync(DotUser user, Claim claim)
		{
			return Task.Run(() =>
			{
				var userClaim = Mapper.Map<UserClaim>(claim);

				user.Claims.Add(userClaim);
			});
		}

		/// <summary>
		/// Get all user claims.
		/// </summary>
		public Task<IList<Claim>> GetClaimsAsync(DotUser user)
		{
			return Task.Run<IList<Claim>>(() =>
			{
				return user.Claims.Select(uc => Mapper.Map<Claim>(uc)).ToList();
			});
		}

		/// <summary>
		/// Remove a claim from the current user.
		/// </summary>
		public Task RemoveClaimAsync(DotUser user, Claim claim)
		{
			return Task.Run(() =>
			{
				var userClaim = user.Claims.SingleOrDefault(c => c.UserId == user.Id && c.ClaimType == claim.Type);

				if (userClaim != null)
					user.Claims.Remove(userClaim);
			});
		}
	}
}