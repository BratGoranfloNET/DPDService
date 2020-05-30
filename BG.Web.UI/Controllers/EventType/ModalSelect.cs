using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
    
    public partial class EventTypeController
    {

        [ChildActionOnly]
        //[HttpGet]
        [Route("modalselect", Name = "EventTypeModalSelectGet")]
        public ActionResult ModalSelect()
        {
            var model = new EventTypeIndexViewModel();

            model.EventTypes  = _eventtypeRepository.GetAll();

            return PartialView(model);
        }

    }
}