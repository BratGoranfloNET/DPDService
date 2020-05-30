using BG.Web.UI.Models;
using System.Web.Mvc;
using BG.Core.Entities;
using System.Collections.Generic;


namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial contacts controller.
	/// </summary>
	public partial class ContactsController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]		
        [Route("vizier", Name = "ContactsVizierEditGet")]

        public ActionResult IndexVizier()
		{
            var model = new ContactsIndexViewModel();

            List<Contact> viziercontacts = new List<Contact>();

            IEnumerable<Contact> contacts = _contactsRepository.GetAll();

            foreach (Contact i in contacts)
            {
                if (i.Type == ContactType.VizierUMTOP  ||
                    i.Type == ContactType.VizierUKS    ||
                    i.Type == ContactType.VizierPROJECT  )
                {
                    viziercontacts.Add(i);
                }
            }

            model.Contacts = viziercontacts;


            return View(model);

        }
	}
}