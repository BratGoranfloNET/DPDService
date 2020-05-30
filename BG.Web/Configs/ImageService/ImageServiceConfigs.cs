using System.Configuration;

namespace BG.Web.Configs
{
	public class ImageServiceConfigs : ConfigurationElement
	{
		[ConfigurationProperty("activeStorageProviderName", IsRequired = true)]
		public string ActiveStorageProviderName
		{
			get { return (string)base["activeStorageProviderName"]; }
			set { base["activeStorageProviderName"] = value; }
		}

		[ConfigurationProperty("", IsDefaultCollection = true)]
		public ImageStorageProviderCollection ImageStorageProviders
		{
			get
			{
				return (ImageStorageProviderCollection)base[""];
			}
		}

		public ImageStorageProviderCollectionItem GetActiveStorageProvider()
		{
			return ImageStorageProviders.GetItem(ActiveStorageProviderName);
		}
	}
}
