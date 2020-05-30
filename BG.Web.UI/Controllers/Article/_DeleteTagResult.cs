using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial productions controller.
	/// </summary>
	public partial class ArticleController
	{
		/// <summary>
		/// Post / Delete action.
		/// </summary>
		[HttpPost]
		[Route("{id:int}/deletetagresult", Name = "TagResultDeletePost")]
		public ActionResult DeleteTagResult(int id)
		{
			var entity = _tagresultRepository.GetTagResultById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

              _tagresultRepository.DeleteTagResult(entity.Id);

			//_timelineService.RegisterActivity(Realm.BG, ActivityType.ProductionDeleted, User.Id);

			return Json(new
			{
				deleted = true,
				name = entity.Id
			});
		}
	}
}