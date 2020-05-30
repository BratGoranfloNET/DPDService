using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BG.Core
{ 
    public class QueryOptions
    {
        public QueryOptions()
        {
            CurrentPage = 1;
            PageSize = 20;

            SortField = "LotId";
            //SortOrder = SortOrder.ASC;
            SortOrder = BG.Core.SortOrder.ASC.ToString();
        }

        [JsonProperty(PropertyName = "sortField")]
        public string SortField { get; set; }


        [JsonProperty(PropertyName = "sortOrder")]
        public string SortOrder { get; set; }
        
        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }


        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }


        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }         

        public int LotId { get; set; }      
        

        [JsonIgnore]
        public string Sort
        {
            get
            {
                return string.Format("{0} {1}",
                    SortField, SortOrder.ToString());
            }

        }
    }
}