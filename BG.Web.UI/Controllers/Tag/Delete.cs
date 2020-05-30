using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class TagController
	{		
		[HttpPost]
		[Route("{id:int}/delete", Name = "TagDeletePost")]
		public ActionResult Delete(int id)
		{
			var entity = _tagRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			_tagRepository.Delete(entity.Id);

			return Json(new
			{
				deleted = true,
				name = entity.Name
			});
		}
	}
}