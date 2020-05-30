using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController
	{
		/// <summary>
		/// Post / Events delete action.
		/// </summary>
		[HttpPost]
		[Route("events/{id:int}/delete", Name = "CalendarEventsDeletePost")]
		public ActionResult EventsDelete(int id)
		{
			var entity = _eventsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			_eventsRepository.Delete(entity.Id);

			_timelineService.RegisterActivity(Realm.BG, ActivityType.EventCreated, User.Id);

			return Json(new
			{
				deleted = true,
				name = entity.Name
			});
		}
	}
}