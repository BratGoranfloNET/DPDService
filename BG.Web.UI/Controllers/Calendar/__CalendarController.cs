using BG.Core.Repositories;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	[Authorize]
	[RoutePrefix("calendar")]
	public partial class CalendarController : BaseController
	{
		private IImageService _imageService = null;
		private IEventsRepository _eventsRepository = null;
		private ILocationsRepository _locationsRepository = null;
		private ITimelineService _timelineService = null;

        // private IProductionRepository _productionRepository = null;
        private IEventTypeRepository _eventtypeRepository = null;


        /// <summary>
        /// Contructor method.
        /// </summary>
        public CalendarController(IImageService imageService,
            IEventsRepository calendarRepository, 
            ILocationsRepository locationsRepository, 
            ITimelineService timelineService,

            // IProductionRepository productionRepository,
            IEventTypeRepository eventtypeRepository)
		{
			_imageService = imageService;
			_eventsRepository = calendarRepository;
			_locationsRepository = locationsRepository;
			_timelineService = timelineService;

            // _productionRepository = productionRepository;
            _eventtypeRepository = eventtypeRepository;

        }
	}
}
