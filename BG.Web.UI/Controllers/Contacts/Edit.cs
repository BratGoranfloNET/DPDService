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
		[Route("{id:int}/edit", Name = "ContactsEditGet")]
		public ActionResult Edit(int id)
		{
			var entity = _contactsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<ContactViewModel>(entity);

			model = BuildModel(model);

            IEnumerable<VizierType> vvtype = VizierType.GetAll();

            model.VizierTypeSelect = new SelectList(
              vvtype
              , "Name" // Id
              , "Name");


            return View("Manager", model);
		}

		/// <summary>
		/// POST / Edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("{id:int}/edit", Name = "ContactsEditPost")]
		public ActionResult Edit(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Contact>(model);

				entity = _contactsRepository.Update(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.ContactUpdated, User.Id);

				Feedback.AddMessageSuccess(ContactResources.ContactEditSuccessMessage);

				return RedirectToAction(nameof(Index), nameof(ContactsController).RemoveControllerSuffix());
			}

			model = BuildModel(model);

			return View("Manager", model);
		}
	}
}