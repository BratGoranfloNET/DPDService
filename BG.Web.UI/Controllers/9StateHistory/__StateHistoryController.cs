using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("statehistory")]
	public partial class StateHistoryController : BaseController
	{
        private IStateHistoryRepository _statehistoryRepository = null;
        public StateHistoryController(
           IStateHistoryRepository statehistoryRepository
            )
		{
            _statehistoryRepository = statehistoryRepository;
            
        }
	}
}