using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BG.Web.UI.Models;
using BG.Core;
using BG.Core.Entities;
using Omu.ValueInjecter;
using BG.Web.UI.ViewModels;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using BG.Core.Resources;
using System.Threading.Tasks;
using BG.Web.UI.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BG.Web.UI.ApiControllers
{

    public class EventDataGet
    {       
        public long periodstart { get; set; }
        public long periodend { get; set; }
        public int enterpriseid { get; set; }
        public int productionid { get; set; }          

    }

    public partial class EventsController
    {

        [HttpGet]
        [Route("getall", Name = "EventGetApi")]
        public List<EventJsonModel> Get([FromUri]EventDataGet eventdata)        
        {                      

            long unixTimeStart = eventdata.periodstart;
            long unixTimeEnd = eventdata.periodend;
            
            DateTime TimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicksStart = unixTimeStart * TimeSpan.TicksPerMillisecond;
            DateTime periodStart = new DateTime(TimeStart.Ticks + unixTimeStampInTicksStart, System.DateTimeKind.Utc);

            DateTime TimeEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicksEnd = unixTimeEnd * TimeSpan.TicksPerMillisecond;
            DateTime periodEnd = new DateTime(TimeStart.Ticks + unixTimeStampInTicksEnd, System.DateTimeKind.Utc);
           
            int enterpriseid = eventdata.enterpriseid;
            int productionid = eventdata.productionid;
        
            List <Event> eventslist = _eventsRepository.GetAll().ToList();

            List<Event> eventslistPeriod2;

            if (productionid == -1)
            {
                eventslistPeriod2 = ( from eve in eventslist
                                      where eve.StartDate >= periodStart // && eve.EndDate  <= periodEnd
                                      where  eve.LocationId == enterpriseid
                                      select eve).ToList();
            }
            else
            {
                eventslistPeriod2 = ( from eve in eventslist
                                      where eve.StartDate >= periodStart //&& eve.EndDate <= periodEnd
                                      where eve.LocationId == enterpriseid //&& eve.ProductionId == productionid
                                      select eve).ToList();

            }

            List<EventJsonModel> eventmodel = new List<EventJsonModel>();

             foreach (Event entity in eventslistPeriod2)             
             {
                long unixTimeStartVM = (long)(entity.StartDate - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                long unixTimeEndVM = (long)(entity.EndDate - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                
                EventJsonModel model = new EventJsonModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.StartDate = unixTimeStartVM;
                model.EndDate = unixTimeEndVM;              
                model.EventTypeId = entity.EventTypeId;
                model.Fio = entity.Fio;
                model.Color = entity.Color;
                eventmodel.Add(model);

             }            

            return eventmodel;           
        }  
    }
}