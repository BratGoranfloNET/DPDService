using BG.Core.Entities;

namespace BG.Services.Timeline
{
	/// <summary>
	/// Timeline service interface.
	/// </summary>
	public interface ITimelineService
	{
		/// <summary>
		/// Build and create an activity.
		/// </summary>
		void RegisterActivity(Realm realm, ActivityType type, int userId);
	}
}
