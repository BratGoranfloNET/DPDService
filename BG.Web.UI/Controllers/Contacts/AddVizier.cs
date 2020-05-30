using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Web.Mvc;
using BG.Core.Resources;
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
		[Route("addvizier", Name = "AddVizierModalGet")]
		public ActionResult AddVizier(ContactViewModes viewMode = ContactViewModes.Vizier, bool enableTypeModification = true)
		{
			var model = new ContactViewModel()
			{
				//Type = contactType,
				ViewMode = viewMode,
				EnableTypeModification = enableTypeModification
			};

			model = BuildModel(model);

            model.Type = ContactType.VizierUMTOP;

            IEnumerable<VizierType> vvtype = VizierType.GetAll();

            model.VizierTypeSelect = new SelectList(
              vvtype
              , "Name" // Id
              , "Name");



            return View("ManagerVizier", model);
        }

		/// <summary>
		/// POST / Modal action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("addvizier", Name = "AddVizierModalPost")]
		public ActionResult AddVizier(ContactViewModel model)
		{
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Contact>(model);

                entity = _contactsRepository.Create(entity);

                _timelineService.RegisterActivity(Realm.BG, ActivityType.ContactCreated, User.Id);

                Feedback.AddMessageSuccess(ContactResources.ContactAddSuccessMessage);

                return RedirectToAction(nameof(IndexVizier), nameof(ContactsController).RemoveControllerSuffix());
            }

            model = BuildModel(model);

            return View("ManagerVizier", model);
        }
	}
}