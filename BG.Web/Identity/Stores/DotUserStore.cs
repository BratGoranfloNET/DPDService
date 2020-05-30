using Microsoft.AspNet.Identity;
using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Repositories;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Platform identity user store partial class.
	/// </summary>
	public partial class DotUserStore : IUserStore<DotUser, int>
	{
		private IUsersRepository _usersRepository = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public DotUserStore(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		/// <summary>
		/// Create user.
		/// </summary>
		public Task CreateAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				var entity = _usersRepository.Create(user);

				user.Id = entity.Id;
			});
		}

		/// <summary>
		/// Find user by id.
		/// </summary>
		public Task<DotUser> FindByIdAsync(int userId)
		{
			return Task.Run(() =>
			{
				var user = _usersRepository.GetById(userId);

				if (user == null)
					return null;

				return Mapper.Map<DotUser>(user);
			});
		}

		/// <summary>
		/// Find user by username OR e-mail. This method is called by the signIn method and we support logging with both options.
		/// </summary>
		public Task<DotUser> FindByNameAsync(string userName)
		{
			return Task.Run(() =>
			{
				User user = null;

				if (RegularExpressions.SimpleEmail.IsMatch(userName))
					user = _usersRepository.GetByEmail(userName);
				else
					user = _usersRepository.GetByUserName(userName);

				if (user == null)
					return null;

				return Mapper.Map<DotUser>(user);
			});
		}

		/// <summary>
		/// Update user.
		/// </summary>
		public Task UpdateAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				var entity = _usersRepository.UpdateIdentity(user);
			});
		}

		/// <summary>
		/// Delete user.
		/// </summary>
		public Task DeleteAsync(DotUser user)
		{
			return Task.Run(() =>
			{
				_usersRepository.Delete(user.Id);
			});
		}

		/// <summary>
		/// Dispose resources.
		/// </summary>
		protected virtual void Dispose(bool disposing) { }

		/// <summary>
		/// Dispose resources.
		/// </summary>
		public void Dispose() => Dispose(true);
	}
}
