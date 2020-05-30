using System.Collections.Generic;
using Newtonsoft.Json;


namespace BG.Web.UI.ViewModels
{
    public class ProductionJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "enterpriseid")]
        public int? LocationId { get; set; }


        [JsonProperty(PropertyName = "enterprisename")]
        public string LocationName { get; set; }


        [JsonProperty(PropertyName = "department")]
        public IEnumerable<DepartmentJsonModel> Departments { get; set; }
        
    }


    public class ProductionWithoutbobyJsonModel
    {
           
        [JsonProperty(PropertyName = "departments")]
        public IEnumerable<DepartmentSimpleJsonModel> Departments { get; set; }

    }

    public class ProductionJsonModel2
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "enterpriseid")]
        public int? LocationId { get; set; }               

    }



    public class ProductionListJsonModel
    {
        [JsonProperty(PropertyName = "production")]
        public List<ProductionJsonModel> Productions { get; set; }

        public ProductionListJsonModel(List<ProductionJsonModel> productions)
        {
            Productions = productions;
        }
        
     }


    public class FULLSTACKJsonModel
    {

        [JsonProperty(PropertyName = "production")]
        public List<ProductionJsonModel2> Productions { get; set; }


        [JsonProperty(PropertyName = "department")]
        public List<DepartmentJsonModel2> Departments { get; set; }


        [JsonProperty(PropertyName = "position")]
        public List<PositionJsonModel2> Positions { get; set; }


        [JsonProperty(PropertyName = "siz")]
        public List<SizJsonModel> Sizs { get; set; }


        [JsonProperty(PropertyName = "sout")]
        public List<SoutJsonModel> Souts { get; set; }


        [JsonProperty(PropertyName = "positionresult")]
        public List<PositionResultJsonModel> PositionResults { get; set; }

        [JsonProperty(PropertyName = "sizresult")]
        public List<SizResultJsonModel> SizResults { get; set; }


        [JsonProperty(PropertyName = "soutresult")]
        public List<SoutResultJsonModel> SoutResults { get; set; }        

        [JsonProperty(PropertyName = "article")]
        public List<ArticleJsonModel> Article { get; set; }

        [JsonProperty(PropertyName = "eventtype")]
        public List<EventTypeJsonModel> EventType { get; set; }

        public FULLSTACKJsonModel(List<ProductionJsonModel2> productions,
                                      List<DepartmentJsonModel2> departments,
                                      List<PositionJsonModel2>   positions,
                                      List<SizJsonModel>         sizs,
                                      List<SoutJsonModel>        souts,
                                      List<PositionResultJsonModel>    positionresults,
                                      List<SizResultJsonModel>         sizresults,
                                      List<SoutResultJsonModel>        soutresults,                                     
                                      List<ArticleJsonModel> article,
                                      List<EventTypeJsonModel> eventtype

                                      )
        {
            Productions = productions;
            Departments = departments;
            Positions = positions;
            Sizs = sizs;
            Souts = souts;
            PositionResults = positionresults;
            SizResults = sizresults;
            SoutResults = soutresults;           
            Article = article;
            EventType = eventtype;
        }
    }
}