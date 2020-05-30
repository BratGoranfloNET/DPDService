using Microsoft.Owin.Security;
using NLog;
using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using BG.Web.Identity;
using BG.Web.Logger;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	[Authorize]
	[RoutePrefix("users")]
	public partial class UsersController : BaseController
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

		public UsersController(
			DotUserManager userManager, 
			DotUserSignInManager signInManager,			
            ILoggerFactory loggerFactory,
			IAuthenticationManager authenticationManager,
			IUsersRepository usersRepository, 
			IImageService imageService, 
			IGlobalizationServices globalizationServices, IActivitiesRepository activitiesRepository, ITimelineService timelineService)
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
