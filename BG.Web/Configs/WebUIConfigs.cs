using System.Configuration;

namespace BG.Web.Configs
{
	public class WebUIConfigs : ConfigsBase
	{
		[ConfigurationProperty("auth.configs", IsRequired = true)]
		public WebUIAuthConfigs Auth
		{
			get { return (WebUIAuthConfigs)base["auth.configs"]; }
			set { base["auth.configs"] = value; }
		}
	}
}
