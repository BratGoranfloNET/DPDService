﻿using BG.Core.Repositories;
using BG.Services.Globalization;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	[Authorize]
	[RoutePrefix("eventtracking")]
	public partial class EventTrackingController : BaseController
	{
        private IEventTrackingRepository _eventtrackingRepository = null;
        public EventTrackingController(
            IEventTrackingRepository eventtrackingRepository			
			)
		{
            _eventtrackingRepository = eventtrackingRepository;
            
        }
	}
}