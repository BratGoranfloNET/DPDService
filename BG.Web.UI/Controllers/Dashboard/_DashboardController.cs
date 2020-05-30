using BG.Core.Repositories;
using System.Web.Mvc;
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
	/// <summary>
	/// Partial dashboard controller.
	/// </summary>
	[Authorize]
	[RoutePrefix("dashboard")]
	public partial class DashboardController : BaseController
	{
        private IEventTrackingRepository  _eventtrackingRepository = null;
        private IEventTrackingTypeRepository _eventtrackingtypeRepository = null;
        private IEventTrackingParameterRepository _eventtrackingparameterRepository = null;
        private IEventTrackingUnitLoadRepository _eventtrackingunitloadRepository = null;

        private IStateParcelsRepository _stateparcelsRepository = null;
        private IStateRepository _stateRepository = null;

        private IStateParcelsUnitedRepository _stateparcelsunitedRepository = null;
        private IStateUnitedRepository _stateunitedRepository = null;
        private IStateHistoryRepository _statehistoryRepository = null;

        private IEventsRepository _eventsRepository = null;


        private DotUserManager _userManager = null;
        private DotUserSignInManager _signInManager = null;
        private IAuthenticationManager _authenticationManager = null;
        private IUsersRepository _usersRepository = null;

        public DashboardController(
            IEventTrackingRepository eventtrackingRepository,
            IEventTrackingTypeRepository eventtrackingtypeRepository,
            IEventTrackingParameterRepository eventtrackingparameterRepository,
            IEventTrackingUnitLoadRepository eventtrackingunitloadRepository,
            IStateParcelsRepository stateparcelsRepository,
            IStateRepository stateRepository,
            IStateParcelsUnitedRepository stateparcelsunitedRepository,
            IStateUnitedRepository stateunitedRepository,
            IStateHistoryRepository statehistoryRepository,
            IEventsRepository eventsRepository,
            DotUserManager userManager,
            DotUserSignInManager signInManager,            
            ILoggerFactory loggerFactory,
            IAuthenticationManager authenticationManager,
            IUsersRepository usersRepository
            )

		{            
            _eventtrackingRepository = eventtrackingRepository;
            _eventtrackingtypeRepository = eventtrackingtypeRepository;
            _eventtrackingparameterRepository = eventtrackingparameterRepository;
            _eventtrackingunitloadRepository = eventtrackingunitloadRepository;

            _stateparcelsRepository = stateparcelsRepository;
            _stateRepository = stateRepository;

            _stateparcelsunitedRepository = stateparcelsunitedRepository;
            _stateunitedRepository = stateunitedRepository;
            _statehistoryRepository = statehistoryRepository;

            _eventsRepository = eventsRepository;

            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _usersRepository = usersRepository;


        }
	}
}
