using BG.Web.UI.Models;
using System.Web.Mvc;
using BG.Core.Entities;
using System.Collections.Generic;
using Omu.ValueInjecter;
using BG.Core.Resources;
using BG.DPDServices;

namespace BG.Web.UI.Controllers
{
	
	public partial class StateUnitedController
	{
		
		[HttpGet]
		[Route("history", Name = "StateHystoryGet")]
		public ActionResult History(string dpdparam)
		{
            DPDWebService dpd = new DPDWebService();
            BG.DPDServices.BGDPDServiceTracing.stateParcels stateParcels =  dpd.GetHistoryByDPDOrderNr(dpdparam);

            List<State> StatesList = new List<State>();

            if (stateParcels.states != null)
            {
                foreach (BG.DPDServices.BGDPDServiceTracing.stateParcel state in stateParcels.states)
                {                    
                    State entityState = new State();
                    entityState = Mapper.Map<State>(state);                    
                    StatesList.Add(entityState);
                }
            }

            var model = new StateIndexViewModel();
            model.States = StatesList;
            return View(model);
		}
	}
}