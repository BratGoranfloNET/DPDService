using BG.Web.UI.Models;
using System;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial alerts controller.
	/// </summary>
	public partial class AlertsController
	{
		/// <summary>
		/// Top alerts box information.
		/// </summary>
		[ChildActionOnly]
		[Route("box", Name = "AlertsBox")]
		public ActionResult Box()
		{
			var model = new AlertBoxViewModel();

			model.Alerts.Add(new AlertViewModel()
			{
				Id = Guid.NewGuid(),
				UTCCreation = DateTime.UtcNow,
				Label = "Server is down!",
				Icon = "fa fa-thumbs-down bg-danger"
			});

			model.Alerts.Add(new AlertViewModel()
			{
				Id = Guid.NewGuid(),
				UTCCreation = DateTime.UtcNow,
				Label = "Review lock screen settings.",
				Icon = "fa fa-lock bg-warning",
				Href = Url.Action(nameof(UsersController.Account), nameof(UsersController).RemoveControllerSuffix(), new { @tab = UserAccountTabs.GeneralSettings.ToSlug() })
			});

			model.Alerts.Add(new AlertViewModel()
			{
				Id = Guid.NewGuid(),
				UTCCreation = DateTime.UtcNow,
				Label = "External action sample.",
				Icon = "fa fa-globe bg-success",
				Href = "https://codecanyon.net/item/net-admin-starter-kit/17260689",
				HrefTarget = "_blank"
			});

			return PartialView(model);
		}
	}
}