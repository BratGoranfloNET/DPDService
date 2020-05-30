using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("state")]
	public partial class StateController : BaseController
	{
        private IStateRepository _stateRepository = null;
        public StateController(
            IStateRepository stateRepository			
			)
		{
            _stateRepository = stateRepository;
            
        }
	}
}