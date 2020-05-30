using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
    /// <summary>
    /// Partial productions controller.
    /// </summary>
    public partial class ArticleController
    {
        [HttpPost]
        [Route("{articleid:int}/{tagid:int}/addtag", Name = "AddTagToArticlePost")]
        public ActionResult AddTagToArticle(int articleid, int tagid)
        {               
            TagResult  entity = _tagresultRepository.AddTagToArticle( articleid, tagid);

              // _timelineService.RegisterActivity(Realm.BG, ActivityType.ProductionCreated, User.Id);
              // Feedback.AddMessageSuccess(DepartmentResources.DepartmentAddSuccessMessage);
              //return RedirectToAction(nameof(Index), nameof(DepartmentController).RemoveControllerSuffix());             
              //return View("Manager", model);

            return Json(new
            {
                ок = true
                //name = entity.Name
            });

        }


    }

}