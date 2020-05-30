using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BG.Core.Repositories;
using System.Web.Http;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using BG.Web.UI.Extensions;


namespace BG.Web.UI.ApiControllers
{

    [Authorize]
    [RoutePrefix("api/article")]
    public partial class ArticleController : ApiController
    {
        private IGlobalizationServices _globalizationServices = null;
        private ITimelineService       _timelineService = null;
        private ILocationsRepository   _locationRepository = null; 
        private IArticleRepository     _articleRepository = null;
        private ITagRepository         _tagRepository = null;
        private ITagResultRepository   _tagresultRepository = null;
        public ArticleController(

            IGlobalizationServices globalizationServices,
            ITimelineService       timelineService,
            ILocationsRepository   locationRepository,
            IArticleRepository     articleRepository,
            ITagResultRepository   tagresultRepository,
            ITagRepository         tagRepository

            )

        {
            _globalizationServices = globalizationServices;
            _timelineService       = timelineService;
            _locationRepository    = locationRepository;
            _articleRepository     = articleRepository;
            _tagresultRepository   = tagresultRepository;
            _tagRepository         = tagRepository;

        }

    }

}