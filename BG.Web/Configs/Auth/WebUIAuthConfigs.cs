using System.Configuration;

namespace BG.Web.Configs
{
	public class WebUIAuthConfigs : ConfigurationElement
	{
		[ConfigurationProperty("cookieName", IsRequired = true)]
		public string CookieName
		{
			get { return (string)base["cookieName"]; }
			set { base["cookieName"] = value; }
		}

		[ConfigurationProperty("loginPath", IsRequired = false)]
		public string LoginPath
		{
			get { return (string)base["loginPath"]; }
			set { base["loginPath"] = value; }
		}
	}
}
