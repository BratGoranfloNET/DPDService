using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("stateparcels")]
	public partial class StateParcelsController : BaseController
	{
        private IStateParcelsRepository _stateparcelsRepository = null;
        public StateParcelsController(
            IStateParcelsRepository stateparcelsRepository			
			)
		{
            _stateparcelsRepository = stateparcelsRepository;
            
        }
	}
}