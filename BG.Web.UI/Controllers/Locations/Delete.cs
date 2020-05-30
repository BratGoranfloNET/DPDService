using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class LocationsController
	{
		/// <summary>
		/// Post / Delete action.
		/// </summary>
		[HttpPost]
		[Route("{id:int}/delete", Name = "LocationsDeletePost")]
		public ActionResult Delete(int id)
		{
			var entity = _locationsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			_locationsRepository.Delete(entity.Id);

			_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationDeleted, User.Id);

			return Json(new
			{
				deleted = true,
				name = entity.Name
			});
		}
	}
}