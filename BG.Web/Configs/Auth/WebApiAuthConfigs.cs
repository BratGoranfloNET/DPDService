using System.Configuration;

namespace BG.Web.Configs
{
	public class WebApiAuthConfigs : ConfigurationElement
	{
		[ConfigurationProperty("tokenPath", IsRequired = false)]
		public string TokenPath
		{
			get { return (string)base["tokenPath"]; }
			set { base["tokenPath"] = value; }
		}
	}
}
