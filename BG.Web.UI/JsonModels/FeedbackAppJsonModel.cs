using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{
    public class FeedbackAppTopicJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class FeedbackAppJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "topicid")]
        public int TopicId { get; set; }     

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "production")]
        public string Production { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public double Rate { get; set; }

        [JsonProperty(PropertyName = "date")]
        public long Date { get; set; }
    }

   

    public class FeedbackAppListJsonModel
    {        
        [JsonProperty(PropertyName = "feedbackapp")]
        public List<FeedbackAppJsonModel> FeedbackApp { get; set; }
        public FeedbackAppListJsonModel(List<FeedbackAppJsonModel> feedbackapp)
        {
            FeedbackApp = feedbackapp;
        }
    }
    
}