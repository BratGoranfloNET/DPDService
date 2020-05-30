using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{   
    public class ExtraWorkJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "siz")]
        public List<SizJsonModel> Sizs { get; set; }
                    
    }

    public class ExtraWorkWithoutBodyJsonModel
    {            
        [JsonProperty(PropertyName = "siz")]
        public List<SizJsonModel> Sizs { get; set; }
    }

    public class ExtraWorkSimpleJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } 
    }

}