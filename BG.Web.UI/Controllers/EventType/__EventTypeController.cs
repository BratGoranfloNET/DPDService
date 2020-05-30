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
	[RoutePrefix("eventtype")]
	public partial class EventTypeController : BaseController
	{
		private IImageService _imageService = null;
		private IContactsRepository _contactsRepository = null;
		private ILocationsRepository _locationsRepository = null;
		private IGlobalizationServices _globalizationServices = null;
		private ITimelineService _timelineService = null;

        //private IManufactureRepository _manufactureRepository = null;
        //private IPositionRepository _positionRepository = null;
        private IEventTypeRepository _eventtypeRepository = null;

        /// <summary>
        /// Constructor method.
        /// </summary>
        public EventTypeController(
			IImageService imageService, 
			IContactsRepository contactsRepository, 
			ILocationsRepository locationsRepository, 
			IGlobalizationServices globalizationServices,
            ITimelineService timelineService,

            //IManufactureRepository manufactureRepository,
            //IPositionRepository positionRepository,
            IEventTypeRepository eventtypeRepository)
		{
			_imageService = imageService;
			_contactsRepository = contactsRepository;
			_locationsRepository = locationsRepository;
			_globalizationServices = globalizationServices;
			_timelineService = timelineService;

            //_manufactureRepository = manufactureRepository;
            //_positionRepository = positionRepository;
            _eventtypeRepository = eventtypeRepository;

        }
	}
}