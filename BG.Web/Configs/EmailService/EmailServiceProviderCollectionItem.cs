using System.Configuration;

namespace BG.Web.Configs
{
	public class EmailServiceProviderCollectionItem : ConfigurationElement
	{
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)base["name"]; }
			set { base["name"] = value; }
		}

		[ConfigurationProperty("type", IsRequired = true)]
		public string Type
		{
			get { return (string)base["type"]; }
			set { base["type"] = value; }
		}

		[ConfigurationProperty("parameters", IsRequired = false)]
		public ParameterCollection Parameters
		{
			get { return (ParameterCollection)this["parameters"]; }
		}
	}
}
