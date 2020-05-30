using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	[Authorize]
	[RoutePrefix("tag")]
	public partial class TagController : BaseController
	{
		private IImageService _imageService = null;		
		private IGlobalizationServices _globalizationServices = null;
		private ITimelineService _timelineService = null;      
        private ITagRepository _tagRepository = null;
        public TagController(
			IImageService imageService, 			
			IGlobalizationServices globalizationServices,
            ITimelineService timelineService,          
            ITagRepository tagRepository)
		{
			_imageService = imageService;			
			_globalizationServices = globalizationServices;
			_timelineService = timelineService;
            _tagRepository = tagRepository;

        }
	}
}