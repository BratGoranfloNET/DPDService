using Omu.ValueInjecter;
using BG.Core.Mappers;
using System.Security.Claims;

namespace BG.Core.Entities
{
	/// <summary>
	/// User claim mapper.
	/// </summary>
	public class UserClaim_to_Claim : IClassMapper
	{
		/// <summary>
		/// Configure the map.
		/// </summary>
		public void Configure()
		{
			Mapper.AddMap<UserClaim, Claim>((source) =>
			{
				return new Claim(source.ClaimType, source.ClaimValue);
			});
		}
	}
}
