using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
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
		/// GET / Add action.
		/// </summary>
		[HttpGet]
		[Route("add", Name = "ContactsAddGet")]
		public ActionResult Add()
		{
			var model = new ContactViewModel();

			model = BuildModel(model);

            model.Type = ContactType.Company;

            IEnumerable<VizierType> vvtype = VizierType.GetAll();

            model.VizierTypeSelect = new SelectList(
              vvtype
              , "Name" // Id
              , "Name");


            return View("Manager", model);
		}

		/// <summary>
		/// POST / Add action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("add", Name = "ContactsAddPost")]
		public ActionResult Add(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Contact>(model);

				entity = _contactsRepository.Create(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.ContactCreated, User.Id);

				Feedback.AddMessageSuccess(ContactResources.ContactAddSuccessMessage);

				return RedirectToAction(nameof(Index), nameof(ContactsController).RemoveControllerSuffix());
			}

			model = BuildModel(model);

			return View("Manager", model);
		}
	}
}