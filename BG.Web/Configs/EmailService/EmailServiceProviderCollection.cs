using System;
using System.Configuration;

namespace BG.Web.Configs
{
	[ConfigurationCollection(typeof(EmailServiceProviderCollectionItem), AddItemName = "service.provider")]
	public class EmailServiceProviderCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new EmailServiceProviderCollectionItem();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			if (element == null)
				throw new ArgumentNullException(nameof(element));

			return ((EmailServiceProviderCollectionItem)element).Name;
		}

		public EmailServiceProviderCollectionItem GetItem(string providerName)
		{
			return BaseGet(providerName) as EmailServiceProviderCollectionItem;
		}
	}
}
