using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Activities repository interface.
	/// </summary>
	public interface IActivitiesRepository
	{
		/// <summary>
		/// Create an entity.
		/// </summary>
		Activity Create(Activity entity);

		/// <summary>
		/// Get entities.
		/// </summary>
		IEnumerable<Activity> GetByUserId(int userId, int? top = 15);
	}
}
