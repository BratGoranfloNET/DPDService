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
	[RoutePrefix("article")]
	public partial class ArticleController : BaseController
	{
		private IImageService _imageService = null;
		private IContactsRepository _contactsRepository = null;
		private ILocationsRepository _locationsRepository = null;
		private IGlobalizationServices _globalizationServices = null;
		private ITimelineService _timelineService = null;
               
        private IArticleRepository _articleRepository = null;
        private ICategoryRepository _categoryRepository = null;
        private ITagResultRepository _tagresultRepository = null;


        /// <summary>
        /// Constructor method.
        /// </summary>
        public ArticleController(
			IImageService imageService, 
			IContactsRepository contactsRepository, 
			ILocationsRepository locationsRepository, 
			IGlobalizationServices globalizationServices,
            ITimelineService timelineService,           
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository,
            ITagResultRepository tagresultRepository)
		{
			_imageService = imageService;
			_contactsRepository = contactsRepository;
			_locationsRepository = locationsRepository;
			_globalizationServices = globalizationServices;
			_timelineService = timelineService;
           
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;

            _tagresultRepository = tagresultRepository;

        }
	}
}