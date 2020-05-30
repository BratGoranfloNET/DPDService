using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BG.Core.Entities;

namespace BG.Web.UI.ViewModels
{
    

    public class SurveyJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "finishdate")]
        public long FinishDate { get; set; }



        [JsonProperty(PropertyName = "points")]
        public List<PointJsonModel> Points { get; set; }
               

    }



    public class PointJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        
        [JsonProperty(PropertyName = "surveyid")]
        public int SurveyId { get; set; }


        [JsonProperty(PropertyName = "issingle")]
        public bool IsSingle { get; set; }



        [JsonProperty(PropertyName = "pointvalues")]
        public List<PointValueJsonModel> PointValues { get; set; }

    }


    public class PointValueJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "pointid")]
        public int PointId { get; set; }

    }




}