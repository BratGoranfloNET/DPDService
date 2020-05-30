using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace BG.Web.UI.ViewModels
{
    public class ArticleImageJsonModel
    {

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }


        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }


        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }

}