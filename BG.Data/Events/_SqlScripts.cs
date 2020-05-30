namespace BG.Data.Events
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class EventsRepository
	{
		private const string EventsInsert_Proc = "EventsInsert";
		private const string EventsSelect_Proc = "EventsSelect";
		private const string EventsUpdate_Proc = "EventsUpdate";
		private const string EventsDelete_Proc = "EventsDelete";

		private const string EventImagesCleanup_Proc = "EventImagesCleanup";
		private const string EventImagesInsert_Proc = "EventImagesInsert";

		private const string EventsSearch_Proc = "EventsSearch";
	}
}
