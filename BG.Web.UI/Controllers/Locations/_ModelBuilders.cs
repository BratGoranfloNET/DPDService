using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class LocationsController
	{
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private LocationViewModel BuilModel(LocationViewModel model)
		{
			var contacts = _contactsRepository.GetAllByType(ContactType.General, ContactType.Location);

			var timezones = _globalizationServices.GetTimeZones();

			model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;

			model.TimeZones = new SelectList(
				timezones.OrderBy(t => t.BaseUtcOffset)
				, "Id"
				, "DisplayName"
				, dataGroupField: "BaseUtcOffset"
				, selectedValue: model.TimeZoneId ?? Globalization.TimeZoneInfo.Id
			);

			model.Contacts = new SelectList(
				contacts
				, "Id"
				, "Name"
			);

			return model;
		}
	}
}