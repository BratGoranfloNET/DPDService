using System.Configuration;

namespace BG.Web.Configs
{
	public class ImageStorageProviderCollectionItem : ConfigurationElement
	{
		[ConfigurationProperty("imageUploadMaxLengthInBytes", IsRequired = true)]
		public long ImageUploadMaxLengthInBytes
		{
			get { return (long)base["imageUploadMaxLengthInBytes"]; }
			set { base["imageUploadMaxLengthInBytes"] = value; }
		}

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
