using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System;
using BG.DPDServices;
using BG.Core;
using BG.DPDServices.BGDPDServiceEventTracking;
using BG.DPDServices.BGDPDServiceTracing;

// using auth = BG.Web.UI.BGDPDServiceEventTracking.auth;

namespace BG.Web.UI.Controllers
{
	
	public partial class DashboardController
    {
        
        [HttpGet]
        [Route("dpd", Name = "DashboardDpdPost")]
        public ActionResult Dpd()
        {

            DPDAction dpd_action = new DPDAction(
             _eventtrackingRepository,
             _eventtrackingtypeRepository,
             _eventtrackingparameterRepository,
             _eventtrackingunitloadRepository,
             _stateparcelsRepository,
             _stateRepository,
             _stateparcelsunitedRepository,
             _stateunitedRepository,
             _statehistoryRepository,
             _eventsRepository
            );

           DPDActionResult result = dpd_action.Go();

            if (result.IsOk)
            {

                //_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationDeleted, User.Id);
                Feedback.AddMessageSuccess(result.Message);
                return RedirectToAction("Index", nameof(DashboardController).RemoveControllerSuffix());

            }
            else
            {
                Feedback.AddMessageWarning(result.Message);
                return RedirectToAction("Index", nameof(DashboardController).RemoveControllerSuffix());

            }    

        }

        

        //         return Json(new
        //{
        //	dpd = true
        //});

    }

	}

