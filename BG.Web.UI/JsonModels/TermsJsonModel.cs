using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BG.Core.Entities;

namespace BG.Web.UI.ViewModels
{
    
        public class TermsJsonModel
        {

            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }


            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

        
            [JsonProperty(PropertyName = "name_en")]
            public string NameEn { get; set; }
        

            [JsonProperty(PropertyName = "abr")]
            public string Abr { get; set; }

        
            [JsonProperty(PropertyName = "abr_en")]
            public string AbrEn { get; set; }


            [JsonProperty(PropertyName = "source ")]
            public string Source { get; set; }


            //[JsonProperty(PropertyName = "content")]
            //public string Content { get; set; }
            



    }

    public class TermsJsonModel2
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "name_en")]
        public string NameEn { get; set; }


        [JsonProperty(PropertyName = "abr")]
        public string Abr { get; set; }


        [JsonProperty(PropertyName = "abr_en")]
        public string AbrEn { get; set; }


        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }


        [JsonProperty(PropertyName = "source ")]
        public string Source { get; set; }
        
    }

    public class TermsListJsonModel {

        [JsonProperty(PropertyName = "terms")]
        public List<TermsJsonModel> Terms { get; set; }

        public TermsListJsonModel(List<TermsJsonModel> terms)
        {
            Terms = terms;
        }


    }


    public class TermsSingleJsonModel
    {

        [JsonProperty(PropertyName = "terms_byid")]
        public TermsJsonModel2 Terms { get; set; }

        public TermsSingleJsonModel(TermsJsonModel2 terms)
        {
            Terms = terms;
        }


    }


}