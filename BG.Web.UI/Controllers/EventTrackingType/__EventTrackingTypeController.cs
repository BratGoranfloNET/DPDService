using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("eventtrackingtype")]
	public partial class EventTrackingTypeController : BaseController
	{
        private IEventTrackingTypeRepository _eventtrackingtypeRepository = null;
        public EventTrackingTypeController(
            IEventTrackingTypeRepository eventtrackingtypeRepository			
			)
		{
            _eventtrackingtypeRepository = eventtrackingtypeRepository;
            
        }
	}
}