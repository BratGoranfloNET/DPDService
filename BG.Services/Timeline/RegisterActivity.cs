using BG.Core.Entities;
using System;
using System.Diagnostics;

namespace BG.Services.Timeline
{
	/// <summary>
	/// Partial timeline service implementation.
	/// </summary>
	public partial class TimelineService
	{
		/// <summary>
		/// Build and create an activity.
		/// </summary>
		public void RegisterActivity(Realm realm, ActivityType type, int userId)
		{
			var entity = new Activity();

			entity.Date = DateTime.UtcNow;
			entity.Realm = realm;
			entity.Type = type;
			entity.UserId = userId;
			entity.Signature = Trace.CorrelationManager.ActivityId;

			entity = _activitiesRepository.Create(entity);
		}
	}
}
