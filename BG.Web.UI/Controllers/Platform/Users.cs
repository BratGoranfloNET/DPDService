using Omu.ValueInjecter;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial platform controller.
	/// </summary>
	public partial class PlatformController
	{
		/// <summary>
		/// GET / Users action.
		/// </summary>
		[HttpGet]
		[Route("users", Name = "PlatformUsersGet")]
		public ActionResult Users()
		{
			var model = new PlatformUsersViewModel();

			model.Users = _usersRepository.GetAll().Select(u => Mapper.Map<PlatformUserViewModel>(u)).ToList();

            foreach (PlatformUserViewModel usr in model.Users)
            {
                foreach (string role in usr.Roles)
                {
                    usr.AllRoles = usr.AllRoles + role + " ";
                }
            }


            return View(model);
		}
	}
}
