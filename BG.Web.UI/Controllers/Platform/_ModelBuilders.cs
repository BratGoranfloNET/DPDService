using BG.Core.Entities;
using BG.Web.UI.Models;
using System;
using System.Web.Mvc;
using System.Linq;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial platform controller.
	/// </summary>
	public partial class PlatformController
	{
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private PlatformUserViewModel BuildModel(PlatformUserViewModel model)
		{
			var roles = Enum.GetValues(typeof(Role)).Cast<Role>().Select(r => new
			{
				id = r.ToLowerCaseString(),
				value = r.GetDisplayName()
			});

			model.RoleOptions = new MultiSelectList(
				roles,
				"id",
				"value",
				model.Roles
			);

			return model;
		}
	}
}