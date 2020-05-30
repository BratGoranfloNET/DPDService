using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial contacts controller.
	/// </summary>
	public partial class ContactsController
	{
		/// <summary>
		/// Post / Delete action.
		/// </summary>
		[HttpPost]
		[Route("{id:int}/delete", Name = "ContactsDeletePost")]
		public ActionResult Delete(int id)
		{
			var entity = _contactsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			_contactsRepository.Delete(entity.Id);

			_timelineService.RegisterActivity(Realm.BG, ActivityType.ContactDeleted, User.Id);

			return Json(new
			{
				deleted = true,
				name = entity.Name
			});
		}
	}
}