using System.Configuration;

namespace BG.Web.Configs
{
	/// <summary>
	/// Configuration settings
	/// </summary>
	public class WebApiConfigs : ConfigsBase
	{
		[ConfigurationProperty("auth.configs", IsRequired = true)]
		public WebApiAuthConfigs Auth
		{
			get { return (WebApiAuthConfigs)base["auth.configs"]; }
			set { base["auth.configs"] = value; }
		}
	}
}
