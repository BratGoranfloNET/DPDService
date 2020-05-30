using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
    /// <summary>
    /// Partial contacts controller.
    /// </summary>
    public partial class ContactsController
    {
       
        [ChildActionOnly]
        //[HttpGet]
        [Route("modalselect", Name = "ContactsModalSelectGet")]
        public ActionResult ModalSelect()
        {
            var model = new ContactsIndexViewModel();

            model.Contacts = _contactsRepository.GetAll();

            return PartialView(model);
        }

    }
}