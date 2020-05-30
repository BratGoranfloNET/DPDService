using System;
using System.Configuration;

namespace BG.Web.Configs
{
	[ConfigurationCollection(typeof(ImageStorageProviderCollectionItem), AddItemName = "storage.provider")]
	public class ImageStorageProviderCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ImageStorageProviderCollectionItem();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			if (element == null)
				throw new ArgumentNullException(nameof(element));

			return ((ImageStorageProviderCollectionItem)element).Name;
		}

		public ImageStorageProviderCollectionItem GetItem(string storageProviderName)
		{
			return BaseGet(storageProviderName) as ImageStorageProviderCollectionItem;
		}
	}
}
