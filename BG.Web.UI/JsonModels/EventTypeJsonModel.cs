using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{   
    public class EventTypeJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

}