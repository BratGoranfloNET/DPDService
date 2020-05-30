using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{    
        public class ArticleJsonModel
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }


            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }


            [JsonProperty(PropertyName = "abstract")]
            public string Abstract { get; set; }
        

            [JsonProperty(PropertyName = "tags")]
            public string Tags { get; set; }
        
    }
    


    public class ArticleListJsonModel {

        [JsonProperty(PropertyName = "articles")]
        public List<ArticleJsonModel> Articles { get; set; }

        public ArticleListJsonModel(List<ArticleJsonModel> articles)
        {
            Articles = articles;
        }

    }

    public class ArticleSingleJsonModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }


        [JsonProperty(PropertyName = "abstract")]
        public string Abstract { get; set; }
        

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }
                

    }

}