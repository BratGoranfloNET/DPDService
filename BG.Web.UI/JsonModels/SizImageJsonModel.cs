using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BG.Core.Entities;


namespace BG.Web.UI.ViewModels
{
    public class SizImageJsonModel
    {


        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }


        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }


        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        

    }

}