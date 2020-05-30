using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// Gets the view with the updated view model.
		/// </summary>
		[NonAction]
		private ActionResult GetAccountView(UserViewModel model)
		{
			var regionCultures = _globalizationServices.GetRegionCultures();
			var languageCulture = _globalizationServices.GetLanguageCultures();
			var timezones = _globalizationServices.GetTimeZones();

			var activities = _activitiesRepository.GetByUserId(User.Id, top: 10).ToList();

			// Group activities by month and year
			model.Activities = activities.GroupBy(
				activity => activity.Date.ToString("MMMM yyyy")
			).ToDictionary(
				group => group.Key, g => g.ToList()
			);

			model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;

			model.CurrentCultures = new SelectList(
				regionCultures.OrderBy(c => c.DisplayName)
				, "Name"
				, "DisplayName"
				, dataGroupField: "Parent.DisplayName"
				, selectedValue: null
			);

			model.CurrentUICultures = new SelectList(
				languageCulture.OrderBy(c => c.DisplayName)
				, "Name"
				, "DisplayName"
				, dataGroupField: "Parent.DisplayName"
				, selectedValue: null
			);

			model.TimeZones = new SelectList(
				timezones.OrderBy(t => t.BaseUtcOffset)
				, "Id"
				, "DisplayName"
				, dataGroupField: "BaseUtcOffset"
				, selectedValue: null
			);

			return View(nameof(Account), model);
		}

		/// <summary>
		/// GET / Account method.
		/// </summary>
		[HttpGet]
		[Route("account", Name = "UserAccountGet")]
		public ActionResult Account(string tab = null)
		{
            //var  user = _usersRepository.GetById(User.Id);

            var user = _usersRepository.GetByUserName(User.UserName);

            var model = Mapper.Map<UserViewModel>(user);

			model.CurrentTab = tab.ChangeType(UserAccountTabs.Overview);

			return GetAccountView(model);
		}

		/// <summary>
		/// POST / Account method.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("account", Name = "UserAccountPost")]
		public async Task<ActionResult> Account(UserViewModel model, string statusMessageUpdate = null)
		{
			if (ModelState.IsValid)
			{
				model.Id = User.Id;

				if (!statusMessageUpdate.IsNullOrEmpty())
					model.StatusMessage = statusMessageUpdate;

				var user = Mapper.Map<User>(model);

				user = _usersRepository.UpdateProfile(user);

				await RefreshUserClaims(model.Id);

				var successMessage = string.Empty;

				switch (model.CurrentTab)
				{
					case UserAccountTabs.Overview:
						_timelineService.RegisterActivity(Realm.BG, ActivityType.UpdatedItsOwnStatusMessage, user.Id);
						successMessage = UserResources.OverviewDataSuccessMessage;
						break;
					case UserAccountTabs.ProfileInfo:
						_timelineService.RegisterActivity(Realm.BG, ActivityType.UpdatedItsOwnProfileInformation, user.Id);
						successMessage = UserResources.ProfileDataUpdatedSuccessMessage;
						break;
					case UserAccountTabs.GeneralSettings:
						_timelineService.RegisterActivity(Realm.BG, ActivityType.UpdatedItsOwnGeneralSettings, user.Id);
						successMessage = UserResources.SettingsDataUpdatedSuccessMessage;
						break;
				}

				Feedback.AddMessageSuccess(successMessage);

				ConfigureGlobalizationContext(HttpContext, model.CurrentCultureId, model.CurrentUICultureId, model.TimeZoneId);

				return RedirectToAction(nameof(Account), new { @tab = model.CurrentTab.ToSlug() });
			}

			// Remap keeping the posted information
			var entity = _usersRepository.GetById(User.Id);

			model = Mapper.Map<UserViewModel>(entity, model);

			return GetAccountView(model);
		}
	}
}
