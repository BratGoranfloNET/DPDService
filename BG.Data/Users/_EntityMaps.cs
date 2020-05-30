using Dapper;
using BG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BG.Data.Users
{
	/// <summary>
	/// Partial users repository implementation.
	/// </summary>
	public partial class UsersRepository
	{
		/// <summary>
		/// Build the entity object from the query results.
		/// </summary>
		private Func<User, Blob, User> _userMap = (user, blob) =>
		{
			user.ImageBlob = blob;

			return user;
		};

		/// <summary>
		/// From a multi result set, builds a single entity with its related data.
		/// </summary>
		private User BuildEntity(SqlMapper.GridReader reader)
		{
			var entity = reader.Read(_userMap).SingleOrDefault();

			if (entity != null)
			{
				entity.Claims = reader.Read<UserClaim>().ToList();
				entity.Roles = reader.Read<UserRole>().ToList();
			}

			return entity;
		}

		/// <summary>
		/// From a multi result set, builds an entities collection with its related data.
		/// </summary>
		private IEnumerable<User> BuildEntitiesList(SqlMapper.GridReader reader)
		{
			var entities = reader.Read(_userMap).ToList();

			var claimsCollection = reader
				.Read<UserClaim>()
				.GroupBy(uClaim => uClaim.UserId)
				.ToDictionary(group => group.Key, group => group.ToList());

			var rolesCollection = reader
				.Read<UserRole>()
				.GroupBy(uRole => uRole.UserId)
				.ToDictionary(group => group.Key, group => group.ToList());

			foreach (var entity in entities)
			{
				List<UserClaim> claims;
				List<UserRole> roles;

				if (!claimsCollection.TryGetValue(entity.Id, out claims))
					claims = new List<UserClaim>();

				if (!rolesCollection.TryGetValue(entity.Id, out roles))
					roles = new List<UserRole>();

				entity.Claims = claims;
				entity.Roles = roles;
			}

			return entities;
		}
	}
}
