using BG.Web.UI.Models;
using System.Web.Mvc;
using BG.Core.Entities;
using System.Collections.Generic;
using Omu.ValueInjecter;
using BG.Core.Resources;
using System;
using System.Linq;
using BG.DPDServices;
using BG.Web.UI.Extensions;

namespace BG.Web.UI.Controllers
{
    	public partial class StateUnitedController
	{
		
        [Route("getstateunitedajax", Name = "StateUnitedAjaxGet")]
        public ActionResult GetStateUnitedAjax()
		{           
            JsonResult result = new JsonResult();
                        
            List<StateUnited> data = new List<StateUnited>();                  

            data = _stateunitedRepository.GetAll().ToList();

            foreach (StateUnited d in data)
            {

                if (d.Consignor == null ||   d.Consignor == "")
                {
                    d.Consignor = " ";
                }
            }


            // Total record count.
            int totalRecords = data.Count;


            try
            {
                // Initialization.
                string search = Request.Form.GetValues("search[value]")[0];
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);


                // Verification.
                if (!string.IsNullOrEmpty(search) &&
                    !string.IsNullOrWhiteSpace(search))
                {
                    // Apply search
                    data = data.Where(p => p.dpdOrderNr.ToString().ToLower().Contains(search.ToLower())  ||
                                p.Consignor.ToString().ToLower().Contains(search.ToLower())).ToList();
                }

                
                // Sorting.
                 data = this.SortByColumnWithOrder2(order, orderDir, data.ToList());
               

                // Filter record count.
                int recFilter = data.Count();


                // Apply pagination.
                data = data.Skip(startRec).Take(pageSize).ToList();




                    List<StateUnitedJsonViewModel> view_data = data
                     .Select(x => new StateUnitedJsonViewModel().InjectFrom(x))
                     .Cast<StateUnitedJsonViewModel>()
                     .ToList();


                foreach (StateUnitedJsonViewModel d in view_data)
                {

                    d.deliveryAddress_string =  (d.DeliveryAddress == null || d.DeliveryAddress == "") ? " " : d.DeliveryAddress;
                    

                    d.newState = StatusTranslator.Translate(d.newState);                                        
                    d.clientOrderNr  = (d.clientOrderNr  ==  null || d.clientOrderNr == "") ? " " : d.clientOrderNr;
                    d.clientParcelNr = (d.clientParcelNr == null || d.clientParcelNr == "") ? " " : d.clientParcelNr;
                    d.dpdParcelNr = (d.dpdParcelNr == null || d.dpdParcelNr == "") ? " " : d.dpdParcelNr;
                    d.newState = (d.newState == null || d.newState == "") ? " " : d.newState;
                    
                    // d.isReturn = d.isReturn ?? false;
                    // d.isReturnSpecified = d.isReturnSpecified ?? false;

                    d.plandeliverydatestring = ( d.planDeliveryDate.ToShortDateString() == "01.01.0001") ? " " : d.planDeliveryDate.ToString();
                    
                    // d.planDeliveryDateSpecified = d.planDeliveryDateSpecified ?? " ";
                    // d.transitionTime = d.transitionTime ?? " ";

                    d.terminalCode = (d.terminalCode == null || d.terminalCode == "") ? " " : d.terminalCode;
                    d.terminalCity = (d.terminalCity == null || d.terminalCity == "") ? " " : d.terminalCity;
                    d.incidentCode = (d.incidentCode == null || d.incidentCode == "") ? " " : d.incidentCode;
                    d.incidentName = (d.incidentName == null || d.incidentName == "") ? " " : d.incidentName;
                    d.consignee    = (d.consignee == null || d.consignee == "") ? " " : d.consignee;
                    d.DeliveryAddress = (d.DeliveryAddress == null || d.DeliveryAddress == "") ? " " : d.DeliveryAddress;
                    d.DeliveryCity = (d.DeliveryCity == null || d.DeliveryCity == "") ? " " : d.DeliveryCity;
                    d.DeliveryVariant = (d.DeliveryVariant == null || d.DeliveryVariant == "") ? " " : d.DeliveryVariant;
                    d.DeliveryPointCode = (d.DeliveryPointCode == null || d.DeliveryPointCode == "") ? " " : d.DeliveryPointCode;
                    d.DeliveryInterval = (d.DeliveryInterval == null || d.DeliveryInterval == "") ? " " : d.DeliveryInterval;
                    d.PickupAddress = (d.PickupAddress == null || d.PickupAddress == "") ? " " : d.PickupAddress;
                    d.PickupCity = (d.PickupCity == null || d.PickupCity == "") ? " " : d.PickupCity;
                    d.PointCity = (d.PointCity == null || d.PointCity == "") ? " " : d.PointCity;
                    d.Consignee2 = (d.Consignee2 == null || d.Consignee2 == "") ? " " : d.Consignee2;
                    d.Consignor = (d.Consignor == null || d.Consignor == "") ? " " : d.Consignor;
                    d.EventName = (d.EventName == null || d.EventName == "") ? " " : d.EventName;
                    d.EventReason = (d.EventReason == null || d.EventReason == "") ? " " : d.EventReason;
                    d.ProblemName = (d.ProblemName == null || d.ProblemName == "") ? " " : d.ProblemName;
                    d.ReasonName = (d.ReasonName == null || d.ReasonName == "") ? " " : d.ReasonName;
                    d.RejectionReason = (d.RejectionReason == null || d.RejectionReason == "") ? " " : d.RejectionReason;
                    d.OrderType = (d.OrderType == null || d.OrderType == "") ? " " : d.OrderType;
                    d.MomentLocZone = (d.MomentLocZone == null || d.MomentLocZone == "") ? " " : d.MomentLocZone;

                    
                }
                

                // Loading drop down lists.
                result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = view_data }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // return View(model);

            // Return info.
            return result;

        }



        private List<StateUnited> SortByColumnWithOrder2(string order, string orderDir, List<StateUnited> data)
        {
            // Initialization.
            List<StateUnited> lst = new List<StateUnited>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList()
                                                                                                 : data.OrderBy(p => p.Id).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.dpdOrderNr).ToList()
                                                                                                 : data.OrderBy(p => p.dpdOrderNr).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.newState).ToList()
                                                                                                 : data.OrderBy(p => p.newState).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.transitionTime).ToList()
                                                                                                 : data.OrderBy(p => p.transitionTime).ToList();
                        break;




                    default:

                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList()
                                                                                                 : data.OrderBy(p => p.Id).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                // info.
                Console.Write(ex);
            }

            // info.
            return lst;
        }




    }
}