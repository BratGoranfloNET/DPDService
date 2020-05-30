using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial contacts controller.
	/// </summary>
	public partial class ContactsController
	{
		/// <summary>
		/// GET / Modal action.
		/// </summary>
		[HttpGet]
		[Route("modal", Name = "ContactsModalGet")]
		public ActionResult Modal(ContactType contactType = ContactType.General, ContactViewModes viewMode = ContactViewModes.Full, bool enableTypeModification = false)
		{
			var model = new ContactViewModel()
			{
				Type = contactType,
				ViewMode = viewMode,
				EnableTypeModification = enableTypeModification
			};

			model = BuildModel(model);

            IEnumerable<VizierType> vvtype = VizierType.GetAll();

            model.VizierTypeSelect = new SelectList(
              vvtype
              , "Name" // Id
              , "Name");

            return PartialView(model);
		}

		/// <summary>
		/// POST / Modal action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("modal", Name = "ContactsModalPost")]
		public ActionResult Modal(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Contact>(model);

				entity = _contactsRepository.Create(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.ContactCreated, User.Id);

				return Json(entity);
			}

			return JsonError(ModelState);
		}
	}
}