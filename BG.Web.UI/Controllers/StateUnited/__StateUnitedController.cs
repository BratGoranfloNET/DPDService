using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("stateunited")]
	public partial class StateUnitedController : BaseController
	{
        private IStateUnitedRepository _stateunitedRepository = null;
        private IStateHistoryRepository _statehistoryRepository = null;

        public StateUnitedController(
            IStateUnitedRepository stateunitedRepository,
            IStateHistoryRepository statehistoryRepository
            )
		    {
            _stateunitedRepository = stateunitedRepository;
            _statehistoryRepository = statehistoryRepository;
            
        }
	}
}