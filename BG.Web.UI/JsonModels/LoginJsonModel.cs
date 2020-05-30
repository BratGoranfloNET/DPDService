using Newtonsoft.Json;

namespace BG.Web.UI.ViewModels
{
    public class LoginJsonModel
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "expiredtime")]
        public string ExpiredTime { get; set; }

    }
}