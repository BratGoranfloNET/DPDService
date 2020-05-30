using BG.Core.Entities;
using System.Net;

using System.Web.Mvc;
using Omu.ValueInjecter;
using BG.Core.Resources;
using BG.Web.UI.Models;
using BG.Services;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using ClosedXML.Excel;
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using BG.Web.UI.Extensions;

namespace BG.Web.UI.Controllers
{
	
	public partial class DashboardController
    {
        


        //[HttpPost]
        [HttpGet]
        [Route("export", Name = "DashboardExport")]
        public ActionResult Export(string period1, string period2, string consignor1)
        {
            DateTime startDate = DateTime.Parse(period1);
            DateTime endDate = DateTime.Parse(period2);

            var model = new StateUnitedIndexViewModel();

            IEnumerable<StateUnited> statesAll = _stateunitedRepository.GetAll();  
            

            statesAll = statesAll.Where(x => (x.UTCCreation.Date >= startDate.Date && x.UTCCreation.Date <= endDate.Date));


            if (consignor1 != "ВСЕ")
            {
                if (consignor1 == "")
                {
                    statesAll = statesAll.Where(x => x.Consignor == null);
                }
                else
                {
                    statesAll = statesAll.Where(x => x.Consignor == consignor1);
                }

               // ViewBag.PeriodTitle = "С " + period1 + " ПО " + period2 + " " + consignor1;

            }


            //foreach (StateUnited st in statesAll)
            //{
            //    if (st.pickupDate == null)
            //    {
            //        st.pickupDate = 
            //    }
            //}

            model.StateUniteds = statesAll;

            DataTable dt = new DataTable("Отправления");
            dt.Columns.AddRange(new DataColumn[29] {
                                            new DataColumn("Дата создания"),
                                            new DataColumn(StateUnitedResources.transitionTime),
                                            new DataColumn(StateUnitedResources.dpdOrderNr),
                                            new DataColumn(StateUnitedResources.clientOrderNr),
                                            new DataColumn(StateUnitedResources.clientParcelNr),
                                            new DataColumn(StateUnitedResources.newState),
                                            new DataColumn(StateUnitedResources.pickupDate),
                                            new DataColumn(StateUnitedResources.planDeliveryDate),
                                            new DataColumn(StateUnitedResources.terminalCity),
                                            new DataColumn(StateUnitedResources.terminalCode),
                                            new DataColumn(StateUnitedResources.incidentName),
                                            new DataColumn(StateUnitedResources.incidentCode),
                                           

                                            new DataColumn(StateUnitedResources.DeliveryAddress),
                                            new DataColumn(StateUnitedResources.DeliveryCity),
                                            new DataColumn(StateUnitedResources.DeliveryVariant),
                                            new DataColumn(StateUnitedResources.DeliveryPointCode),
                                            new DataColumn(StateUnitedResources.DeliveryInterval),

                                            new DataColumn(StateUnitedResources.PickupAddress),
                                            new DataColumn(StateUnitedResources.PickupCity),
                                            new DataColumn(StateUnitedResources.PointCity),
                                            new DataColumn(StateUnitedResources.Consignee2),
                                            new DataColumn(StateUnitedResources.Consignor),
                                            new DataColumn(StateUnitedResources.EventName),

                                            new DataColumn(StateUnitedResources.EventReason),
                                            new DataColumn(StateUnitedResources.ProblemName),
                                            new DataColumn(StateUnitedResources.ReasonName),
                                            new DataColumn(StateUnitedResources.RejectionReason),
                                            new DataColumn(StateUnitedResources.OrderType),
                                            new DataColumn(StateUnitedResources.MomentLocZone)
                                             
                                             });


            foreach (var state in model.StateUniteds)
            {        
                
                    dt.Rows.Add(
                        state.UTCCreation,
                        state.transitionTime.ToShortDateString() != "01.01.0001" ? state.transitionTime.ToShortDateString() + " " + state.transitionTime.ToShortTimeString() : "",                        
                        state.dpdOrderNr,
                        state.clientOrderNr,
                        state.clientParcelNr,
                        StatusTranslator.Translate(state.newState),
                        state.pickupDate.ToShortDateString() != "01.01.0001" ?  state.pickupDate.ToShortDateString() : "",
                        state.planDeliveryDate.ToShortDateString() != "01.01.0001" ? state.planDeliveryDate.ToShortDateString() : "",                        
                        state.terminalCity,
                        state.terminalCode,
                        state.incidentName,
                        state.incidentCode,                      
                        state.DeliveryAddress, 
                        state.DeliveryCity,
                        state.DeliveryVariant,
                        state.DeliveryPointCode,
                        state.DeliveryInterval,
                        state.PickupAddress,
                        state.PickupCity,
                        state.PointCity,
                        state.Consignee2,
                        state.Consignor,
                        state.EventName,

                         state.EventReason,
                         state.ProblemName,
                         state.ReasonName,
                         state.RejectionReason,
                         state.OrderType,
                         state.MomentLocZone 

                        );
               

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "States.xlsx");
                }

            }
        }

	}
}