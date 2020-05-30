using System.Configuration;

namespace BG.Web.Configs
{
	/// <summary>
	/// Common set of web configurations between different web applications.
	/// </summary>
	public abstract class ConfigsBase : ConfigurationSection
	{
		/// <summary>
		/// Email service related configurations.
		/// </summary>
		[ConfigurationProperty("emailservice.configs", IsRequired = true)]
		public EmailServiceConfigs EmailService
		{
			get { return (EmailServiceConfigs)base["emailservice.configs"]; }
			set { base["emailservice.configs"] = value; }
		}

		/// <summary>
		/// Image service related configurations.
		/// </summary>
		[ConfigurationProperty("imageservice.configs", IsRequired = true)]
		public ImageServiceConfigs ImageService
		{
			get { return (ImageServiceConfigs)base["imageservice.configs"]; }
			set { base["imageservice.configs"] = value; }
		}
	}
}
