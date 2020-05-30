using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{    
        public class DepartmentJsonModel
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "positions")]
            public List<PositionJsonModel> Positions { get; set; }

            [JsonProperty(PropertyName = "productionid")]
            public int? ProductionId { get; set; }
        }

        public class DepartmentSimpleJsonModel
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "productionid")]
            public int? ProductionId { get; set; }

        }

        public class DepartmentWithoutbobyJsonModel
        {       

            [JsonProperty(PropertyName = "positions")]
            public List<PositionOnlybobyJsonModel> Positions { get; set; }
               
        }

        public class DepartmentJsonModel2
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "productionid")]
            public int? ProductionId { get; set; }
        }

        public class DepartmentOnlybobyJsonModel
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }        

        }

}