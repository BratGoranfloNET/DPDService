using BG.Core.Repositories;

namespace BG.Services.Timeline
{
	/// <summary>
	/// Partial timeline service implementation.
	/// </summary>
	public partial class TimelineService : ITimelineService
	{
		private IActivitiesRepository _activitiesRepository = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public TimelineService(IActivitiesRepository activitiesRepository)
		{
			_activitiesRepository = activitiesRepository;
		}
	}
}
