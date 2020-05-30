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
	public partial class EventTrackingParameterController
    {
        [Route("geteventtrackingparameterajax", Name = "EventTrackingParameterAjaxGet")]
        public ActionResult GetEventTrackingParameterAjax()
		{
            JsonResult result = new JsonResult();
           
            List<EventTrackingParameter> data = new List<EventTrackingParameter>();
                     
            data = _eventtrackingparameterRepository.GetAll().ToList();


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
                    data = data.Where(p => p.paramName.ToString().ToLower().Contains(search.ToLower()) // ||
                                          // p.newState.ToLower().Contains(search.ToLower()) ||
                                          // p.transitionTime.ToString().ToLower().Contains(search.ToLower())
                                           ).ToList();
                }

                
                // Sorting.
                 data = this.SortByColumnWithOrder2(order, orderDir, data.ToList());
               

                // Filter record count.
                int recFilter = data.Count();


                // Apply pagination.
                data = data.Skip(startRec).Take(pageSize).ToList();


                    List<EventTrackingParameterJsonViewModel> view_data = data
                     .Select(x => new EventTrackingParameterJsonViewModel().InjectFrom(x))
                     .Cast<EventTrackingParameterJsonViewModel>()
                     .ToList();


                foreach (EventTrackingParameterJsonViewModel d in view_data)
                {

                    d.paramName = (d.paramName == null || d.paramName == "") ? " " : d.paramName;
                    d.valueString = (d.valueString == null || d.valueString == "") ? " " : d.valueString;                    
                    d.valueDecimalstring = (d.valueDecimal == 0) ? " " : d.valueDecimal.ToString();

                    d.valueDateTimestring = (d.valueDateTime.ToShortDateString() == "01.01.0001") ? " " : d.valueDateTime.ToString();

                    d.type = (d.type == null || d.type == "") ? " " : d.type;

                }
                

                // Loading drop down lists.
                result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = view_data }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

           
            return result;

        }



        private List<EventTrackingParameter> SortByColumnWithOrder2(string order, string orderDir, List<EventTrackingParameter> data)
        {
            // Initialization.
            List<EventTrackingParameter> lst = new List<EventTrackingParameter>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.paramName).ToList()
                                                                                                 : data.OrderBy(p => p.paramName).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.valueString).ToList()
                                                                                                 : data.OrderBy(p => p.valueString).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.valueDecimal).ToList()
                                                                                                 : data.OrderBy(p => p.valueDecimal).ToList();
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