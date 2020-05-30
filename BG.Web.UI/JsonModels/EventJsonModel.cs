using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{    
        public class EventJsonModel
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

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

}