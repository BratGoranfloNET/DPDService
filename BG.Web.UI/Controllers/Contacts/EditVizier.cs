using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Net;
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
		/// GET / Edit action.
		/// </summary>
		[HttpGet]
		[Route("{id:int}/editvizier", Name = "ContactsEditVizierGet")]
		public ActionResult EditVizier(int id)
		{
			var entity = _contactsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<ContactViewModel>(entity);

			model = BuildModel(model);

            model.ViewMode = ContactViewModes.Vizier;


            IEnumerable<VizierType> vvtype = VizierType.GetAll();

            model.VizierTypeSelect = new SelectList(
              vvtype
              , "Name" // Id
              , "Name");


            return View("ManagerVizier", model);
		}

		/// <summary>
		/// POST / Edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("{id:int}/editvizier", Name = "ContactsEditVizierPost")]
		public ActionResult EditVizier(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Contact>(model);

				entity = _contactsRepository.Update(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.ContactUpdated, User.Id);

				Feedback.AddMessageSuccess(ContactResources.ContactEditSuccessMessage);

				return RedirectToAction(nameof(IndexVizier), nameof(ContactsController).RemoveControllerSuffix());
			}

			model = BuildModel(model);

			return View("ManagerVizier", model);
		}
	}
}