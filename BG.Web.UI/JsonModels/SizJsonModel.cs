using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BG.Core.Entities;

namespace BG.Web.UI.ViewModels
{
    
    public class SizJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "season")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Season? Season { get; set; }


        [JsonProperty(PropertyName = "kolvo")]
        public string Kolvo { get; set; }


        [JsonProperty(PropertyName = "srok")]
        public string Srok { get; set; }


        //[JsonProperty(PropertyName = "votes")]
        //public int Votes { get; set; }


        //[JsonProperty(PropertyName = "totalrating")]
        //public double TotalRating { get; set; }


        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; }


        [JsonProperty(PropertyName = "images")]
        public List<SizImageJsonModel> Images { get; set; } = new List<SizImageJsonModel>();


        [JsonProperty(PropertyName = "positionid")]
        public int PositionId { get; set; }


        [JsonProperty(PropertyName = "extraworkid")]
        public int ExtraWorkId { get; set; }


        [JsonProperty(PropertyName = "groupid")]
        public int GroupId { get; set; }


        //[JsonProperty(PropertyName = "picture")]
        //public string PictureUrl { get; set; }


    }

    public class SizResultJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        


        [JsonProperty(PropertyName = "positionid")]
        public int? PositionId { get; set; }


        [JsonProperty(PropertyName = "sizid")]
        public int? SizId { get; set; }



        [JsonProperty(PropertyName = "groupid")]
        public int? GroupId { get; set; }
       

    }
    

}