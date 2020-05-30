using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial platform controller.
	/// </summary>
	public partial class PlatformController
	{
		/// <summary>
		/// GET / Users edit action.
		/// </summary>
		[HttpGet]
		[Route("users/{id:int}/edit", Name = "PlatformUsersEditGet")]
		public ActionResult UsersEdit(int id)
		{
			var entity = _usersRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<PlatformUserViewModel>(entity);

			model = BuildModel(model);

			return View("UsersManager", model);
		}

		/// <summary>
		/// POST / Users edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("users/{id:int}/edit", Name = "PlatformUsersEditPost")]
		public ActionResult UsersEdit(int id, PlatformUserViewModel model)
		{
			var entity = _usersRepository.GetById(id);

			if (ModelState.IsValid)
			{
				entity.Roles = model.Roles.Select(r => new UserRole() {
					Role = r.ChangeType<Role>(), UserId = id
				}).ToList();

				entity = _usersRepository.UpdateIdentity(entity);

				Feedback.AddMessageSuccess(UserResources.UserEditSuccessMessage);

				return RedirectToAction(nameof(Users), nameof(PlatformController).RemoveControllerSuffix());
			}

			model = Mapper.Map<PlatformUserViewModel>(entity, model);

			model = BuildModel(model);

			return View("UsersManager", model);
		}

	}
}
