using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Users repository interface.
	/// </summary>
	public interface IUsersRepository : ISearchableRepository<User>
	{
		/// <summary>
		/// Create user.
		/// </summary>
		User Create(User user);

		/// <summary>
		/// Get users.
		/// </summary>
		IEnumerable<User> GetAll();

		/// <summary>
		/// Get user by id.
		/// </summary>
		User GetById(int userId);

		/// <summary>
		/// Get user by e-mail.
		/// </summary>
		User GetByEmail(string email);

		/// <summary>
		/// Get user by username.
		/// </summary>
		User GetByUserName(string userName);

		/// <summary>
		/// Update user profile data.
		/// </summary>
		User UpdateProfile(User user);

		/// <summary>
		/// Update user profile and identity (password, hashes, etc..) data.
		/// </summary>
		User UpdateIdentity(User user);

		/// <summary>
		/// Delete user.
		/// </summary>
		void Delete(int userId);
	}
}
