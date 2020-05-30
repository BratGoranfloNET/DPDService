using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{
    public class PositionJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "siz")]
        public List<SizJsonModel> Sizs { get; set; }

        [JsonProperty(PropertyName = "sout")]
        public List<SoutJsonModel> Souts { get; set; }

    }

    public class PositionWithoutBodyJsonModel
    {

        [JsonProperty(PropertyName = "siz")]
        public List<SizJsonModel> Sizs { get; set; }

        [JsonProperty(PropertyName = "sout")]
        public List<SoutJsonModel> Souts { get; set; }

    }


    public class PositionJsonModel2
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } 

    }

    public class PositionOnlybobyJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "departmentid")]
        public int DepartmentId { get; set; }

    }


    public class PositionResultJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }             
        

        [JsonProperty(PropertyName = "positionid")]
        public int? PositionId { get; set; }


        [JsonProperty(PropertyName = "departmentid")]
        public int? DepartmentId { get; set; }
        
    }

}