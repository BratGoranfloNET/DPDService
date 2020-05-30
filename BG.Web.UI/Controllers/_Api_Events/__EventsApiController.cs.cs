using BG.Core.Repositories;
using System.Web.Http;
using BG.Services.Globalization;
using BG.Services.Timeline;

namespace BG.Web.UI.ApiControllers
{

    [Authorize]
    [RoutePrefix("api/events")]
    public partial class EventsController : ApiController
    {
        private IGlobalizationServices _globalizationServices = null;
        private ITimelineService       _timelineService = null;
        private IEventsRepository      _eventsRepository = null;
        private ILocationsRepository   _locationRepository = null;     
        private IEventTypeRepository   _eventtypeRepository = null;

        public EventsController(

            IGlobalizationServices globalizationServices,
            ITimelineService       timelineService,
            IEventsRepository      eventsRepository,
            ILocationsRepository   locationRepository,          
            IEventTypeRepository eventtypeRepository)                        

        {
            _globalizationServices = globalizationServices;
            _timelineService       = timelineService;
            _eventsRepository      = eventsRepository;
            _locationRepository    = locationRepository;
            _eventtypeRepository   = eventtypeRepository;
        }
    }
}