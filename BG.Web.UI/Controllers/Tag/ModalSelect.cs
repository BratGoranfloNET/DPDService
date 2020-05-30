using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{    
    public partial class TagController
    {

        [ChildActionOnly]      
        [Route("modalselect", Name = "TagModalSelectGet")]
        public ActionResult ModalSelect()
        {
            var model = new TagIndexViewModel();
            model.Tags  = _tagRepository.GetAll();
            return PartialView(model);
        }
    }
}