using System.Configuration;

namespace BG.Web.Configs
{
	/// <summary>
	/// Represent a parameter item from the app configuration file.
	/// </summary>
	public class ParameterCollectionItem : ConfigurationElement
	{
		/// <summary>
		/// Gets or sets the parameter key.
		/// </summary>
		[ConfigurationProperty("key", IsKey = true, IsRequired = true)]
		public string Key
		{
			get { return (string)base["key"]; }
			set { base["key"] = value; }
		}

		/// <summary>
		/// Gets or sets the parameter value.
		/// </summary>
		[ConfigurationProperty("value", IsRequired = true)]
		public string Value
		{
			get { return (string)base["value"]; }
			set { base["value"] = value; }
		}
	}
}
