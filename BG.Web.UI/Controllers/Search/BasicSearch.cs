using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial search controller.
	/// </summary>
	public partial class SearchController
	{
		/// <summary>
		/// GET / Basic search action.
		/// </summary>
		[Route("basic", Name = "SearchBasic")]
		public ActionResult BasicSearch(string query)
		{
			var model = new SearchViewModel(query);

			var results = _searchService.Search(model.Query);

			// Contacts
			model.Items.AddRange(results.Contacts.Select(entity => Mapper.Map<ContactViewModel>(entity)));
			model.Medias.AddRange(
				results.Contacts.Where(
					entity => entity.ImageBlobId.HasValue
				).Select(
					entity => new SearchResultMediaViewModel()
					{
						Image = entity.ImageBlob.Name,
						ItemLabel = entity.Name,
						NavigationPath = Url.Action(nameof(ContactsController.Edit), nameof(ContactsController).RemoveControllerSuffix(), new { @id = entity.Id })
					}
				)
			);

			// Locations
			model.Items.AddRange(results.Locations.Select(entity => Mapper.Map<LocationViewModel>(entity)));
			model.Medias.AddRange(
				results.Locations.Where(
					entity => entity.ImageBlobId.HasValue
				).Select(
					entity => new SearchResultMediaViewModel()
					{
						Image = entity.ImageBlob.Name,
						ItemLabel = entity.Name,
						NavigationPath = Url.Action(nameof(LocationsController.Edit), nameof(LocationsController).RemoveControllerSuffix(), new { @id = entity.Id })
					}
				)
			);

			// Events
			model.Items.AddRange(results.Events.Select(entity => Mapper.Map<CalendarEventViewModel>(entity)));
			model.Medias.AddRange(
				results.Events.Where(
					entity => entity.Images != null && entity.Images.Count > 0
				).SelectMany(
					entity => entity.Images.Select(
						image => new SearchResultMediaViewModel()
						{
							Image = image.Name,
							ItemLabel = image.Label,
							ItemSubLabel = entity.Name,
							NavigationPath = Url.Action(nameof(CalendarController.EventsEdit), nameof(CalendarController).RemoveControllerSuffix(), new { @id = entity.Id })
						}
					)
				)
			);

			// Users
			if (User.IsInRole(Role.Admin))
			{
				model.Items.AddRange(results.Users.Select(entity => Mapper.Map<UserViewModel>(entity)));
				model.Medias.AddRange(
					results.Users.Where(
						entity => entity.ImageBlobId.HasValue
					).Select(
						entity => new SearchResultMediaViewModel()
						{
							Image = entity.ImageBlob.Name,
							ItemLabel = entity.Name,
							NavigationPath = Url.Action(nameof(PlatformController.UsersEdit), nameof(PlatformController).RemoveControllerSuffix(), new { @id = entity.Id })
						}
					)
				);
			}

			return View("Results", model);
		}
	}
}