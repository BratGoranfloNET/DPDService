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
using BG.Web.UI.ViewModels;
using Microsoft.Owin.Security;
using NLog;
using BG.Web.Identity;
using BG.Web.Logger;


namespace BG.Web.UI.ApiControllers
{

    [Authorize]
    [RoutePrefix("api/login")]
    public partial class LoginController : ApiController
    {
        private ILogger _logger = null;
        private DotUserManager _userManager = null;
        private DotUserSignInManager _signInManager = null;
        private IAuthenticationManager _authenticationManager = null;
        private IUsersRepository _usersRepository = null;
        private IImageService _imageService = null;
        private IGlobalizationServices _globalizationServices = null;
        private IActivitiesRepository _activitiesRepository = null;
        private ITimelineService _timelineService = null;

        public LoginController(
            DotUserManager userManager,
            DotUserSignInManager signInManager,           
            ILoggerFactory loggerFactory,
            IAuthenticationManager authenticationManager,
            IUsersRepository usersRepository,
            IImageService imageService,
            IGlobalizationServices globalizationServices,
            IActivitiesRepository activitiesRepository,
            ITimelineService timelineService

            )

        {
            _logger = loggerFactory.Create();
			_userManager = userManager;
			_signInManager = signInManager;
			_authenticationManager = authenticationManager;
			_usersRepository = usersRepository;
			_imageService = imageService;
			_globalizationServices = globalizationServices;
			_activitiesRepository = activitiesRepository;
			_timelineService = timelineService;        

        }
    }
}