using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	public partial class EventTypeController
	{
		/// <summary>
		/// Post / Delete action.
		/// </summary>
		[HttpPost]
		[Route("{id:int}/delete", Name = "EventTypeDeletePost")]
		public ActionResult Delete(int id)
		{
			var entity = _eventtypeRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			_eventtypeRepository.Delete(entity.Id);

			//_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationDeleted, User.Id);

			return Json(new
			{
				deleted = true,
				name = entity.Name
			});
		}
	}
}