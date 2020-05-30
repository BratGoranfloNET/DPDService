using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("eventtrackingparameter")]
	public partial class EventTrackingParameterController : BaseController
	{
        private IEventTrackingParameterRepository _eventtrackingparameterRepository = null;
        public EventTrackingParameterController(
            IEventTrackingParameterRepository eventtrackingparameterRepository			
			)
		{
            _eventtrackingparameterRepository = eventtrackingparameterRepository;
            
        }
	}
}