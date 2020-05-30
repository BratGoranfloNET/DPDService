using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	[Authorize]
	[RoutePrefix("locations")]
	public partial class LocationsController : BaseController
	{
		private IImageService _imageService = null;
		private IContactsRepository _contactsRepository = null;
		private ILocationsRepository _locationsRepository = null;
		private IGlobalizationServices _globalizationServices = null;
		private ITimelineService _timelineService = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public LocationsController(
			IImageService imageService, 
			IContactsRepository contactsRepository, 
			ILocationsRepository locationsRepository, 
			IGlobalizationServices globalizationServices, ITimelineService timelineService)
		{
			_imageService = imageService;
			_contactsRepository = contactsRepository;
			_locationsRepository = locationsRepository;
			_globalizationServices = globalizationServices;
			_timelineService = timelineService;
		}
	}
}