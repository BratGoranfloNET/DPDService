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
        [Route("gethistoryajax", Name = "StateHystoryAjaxGet")]
        public ActionResult GetHistoryAjax(int stateunitedid)
		{            
            JsonResult result = new JsonResult();
          
            List<StateHistory> data = new List<StateHistory>();


            var stateunited = _stateunitedRepository.GetById(stateunitedid);

            string dpdparam = stateunited.dpdOrderNr;

            data = _statehistoryRepository.GetListByDPDParam(dpdparam).ToList();

            foreach (StateHistory d in data)
            {
                d.newState = StatusTranslator.Translate(d.newState);
            }                                                                
            
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
                    data = data.Where(p => p.dpdOrderNr.ToString().ToLower().Contains(search.ToLower()) ||
                                           p.newState.ToLower().Contains(search.ToLower()) ||
                                           p.transitionTime.ToString().ToLower().Contains(search.ToLower())).ToList();
                }



                // Sorting.
                 data = this.SortByColumnWithOrder(order, orderDir, data.ToList());
               

                // Filter record count.
                int recFilter = data.Count();

                // Apply pagination.
                data = data.Skip(startRec).Take(pageSize).ToList();



                // Loading drop down lists.
                result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
               
                Console.Write(ex);
            }
         
            return result;

        }



        private List<StateHistory> SortByColumnWithOrder(string order, string orderDir, List<StateHistory> data)
        {
            // Initialization.
            List<StateHistory> lst = new List<StateHistory>();

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