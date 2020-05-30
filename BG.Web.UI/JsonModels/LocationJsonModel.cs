using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{    
    public class LocationJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }


        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }


        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

    }
    


    public class LocationListJsonModel
    {
        [JsonProperty(PropertyName = "enterprise")]
        public List<LocationJsonModel> Locations { get; set; }

        public LocationListJsonModel(List<LocationJsonModel> locations)
        {
            Locations = locations;
        }

    }


    
    public class LocationListAllDataJsonModel
    {
        [JsonProperty(PropertyName = "data")]
        public ProductionListJsonModel Productions { get; set; }                

    }

    public class ALLDATAJsonModel
    {
        [JsonProperty(PropertyName = "data")]
        public FULLSTACKJsonModel FULLSTACK { get; set; }   
    }

}