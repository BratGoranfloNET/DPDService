using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BG.Core.Entities;

namespace BG.Web.UI.ViewModels
{
    

    public class SoutJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        //[JsonProperty(PropertyName = "function_code")]
        //public string FunctionCode { get; set; }


        //[JsonProperty(PropertyName = "function_name")]
        //public string FunctionName { get; set; }


        //[JsonProperty(PropertyName = "direction_code")]
        //public string DirectionCode { get; set; }


        //[JsonProperty(PropertyName = "fdirection_name")]
        //public string DirectionName { get; set; }


        //[JsonProperty(PropertyName = "mvz_name")]
        //public string MvzName { get; set; }


        [JsonProperty(PropertyName = "fclass")]
        public string Class { get; set; }


        [JsonProperty(PropertyName = "payment_addition")]
        public bool PaymentAdditional { get; set; }



        [JsonProperty(PropertyName = "holiday_addition")]
        public bool HolydayAdditional { get; set; }


        [JsonProperty(PropertyName = "milk_addition")]
        public bool MilkAdditional { get; set; }


        [JsonProperty(PropertyName = "pension_addition")]
        public bool PensionAdditional { get; set; }



        [JsonProperty(PropertyName = "work_time_reduction")]
        public bool WorkTimeReduction { get; set; }


        [JsonProperty(PropertyName = "position_category")]
        public string PositionCategory { get; set; } = "-";


        [JsonProperty(PropertyName = "stavka")]
        public string Stavka { get; set; } = "-";



        [JsonProperty(PropertyName = "positionid")]
        public int PositionId { get; set; }


        [JsonProperty(PropertyName = "extraworkid")]
        public int ExtraWorkId { get; set; }


       

    }


    public class SoutResultJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        


        [JsonProperty(PropertyName = "positionid")]
        public int? PositionId { get; set; }


        [JsonProperty(PropertyName = "soutid")]
        public int? SoutId { get; set; }




    }

}