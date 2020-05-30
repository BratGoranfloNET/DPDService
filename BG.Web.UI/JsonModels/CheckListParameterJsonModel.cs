using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{
        public class CheckListParameterJsonModel 
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }


            [JsonProperty(PropertyName = "categoryid")]
            public int? CheckListCategoryId { get; set; }


            [JsonProperty(PropertyName = "typeid")]
            public int? CheckListTypeId { get; set; }       
        }

        public class CheckListCategoryJsonModel
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
        }



        public class CheckListTypeJsonModel
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
        }


    public class CheckListFULLListJsonModel
    {
        [JsonProperty(PropertyName = "checklistparameter")]
        public List<CheckListParameterJsonModel> CheckListParameters { get; set; }


        [JsonProperty(PropertyName = "checklistcategory")]
        public List<CheckListCategoryJsonModel> CheckListCategories { get; set; }


        [JsonProperty(PropertyName = "checklisttype")]
        public List<CheckListTypeJsonModel> CheckListTypes { get; set; }

        public CheckListFULLListJsonModel(List<CheckListParameterJsonModel> checklistparameters, 
                                              List<CheckListCategoryJsonModel>  checklistcategories,
                                              List<CheckListTypeJsonModel> checklisttypes)
        {
            CheckListParameters = checklistparameters;
            CheckListCategories = checklistcategories;
            CheckListTypes = checklisttypes;
        }
    }
}