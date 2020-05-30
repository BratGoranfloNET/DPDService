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



namespace BG.Web.UI.ApiControllers
{

    public class EventData
    {
        

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "startdate")]
        public long StartDate { get; set; }


        [JsonProperty(PropertyName = "enddate")]
        public long EndDate { get; set; }
       

        [JsonProperty(PropertyName = "productionid")]
        public int? ProductionId { get; set; }


        [JsonProperty(PropertyName = "eventtypeid")]
        public int? EventTypeId { get; set; }


        [JsonProperty(PropertyName = "fio")]
        public string Fio { get; set; }


        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
        

    }



    public partial class EventsController
    {

        [HttpPost]
        [Route("add", Name = "EventPostApi")]      
        public int Post(EventData eventData)
        {

            int? LocationId = null;


            if (eventData != null)
            {
                Event entity = new Event();
                entity.Name = eventData.Name;
                entity.StartDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds(eventData.StartDate);
                entity.EndDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddMilliseconds(eventData.EndDate);              
                entity.LocationId = LocationId;               
                entity.EventTypeId = eventData.EventTypeId;
                entity.Fio = eventData.Fio;
                entity.Color = eventData.Color;
                              
                if (entity.Name != null   & entity.Fio != null)
                    {
                    _eventsRepository.Create(entity);
                }
                else
                {
                    return 0;
                }

                return entity.Id;

            }


            return 0;

        }

    }
}

