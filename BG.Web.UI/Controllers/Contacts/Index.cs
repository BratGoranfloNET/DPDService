using BG.Web.UI.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using BG.Core.Entities;

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
		[Route(Name = "ContactsIndexGet")]
		public ActionResult Index()
		{

             var model = new ContactsIndexViewModel();
            // model.Contacts = _contactsRepository.GetAll();
            
            List<Contact> viziercontacts = new List<Contact>();

            IEnumerable<Contact> contacts = _contactsRepository.GetAll();

            foreach (Contact i in contacts)
            {
                if (i.Type != ContactType.VizierUMTOP &&
                    i.Type != ContactType.VizierUKS &&
                    i.Type != ContactType.VizierPROJECT)
                {
                    viziercontacts.Add(i);
                }
            }

            model.Contacts = viziercontacts;



            return View(model);
            
		}
	}
}