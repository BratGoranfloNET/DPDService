using System.Configuration;

namespace BG.Web.Configs
{
	public class EmailServiceConfigs : ConfigurationElement
	{
		[ConfigurationProperty("activeProviderName", IsRequired = true)]
		public string ActiveProviderName
		{
			get { return (string)base["activeProviderName"]; }
			set { base["activeProviderName"] = value; }
		}

		[ConfigurationProperty("senderDisplayName", IsRequired = true)]
		public string SenderDisplayName
		{
			get { return (string)base["senderDisplayName"]; }
			set { base["senderDisplayName"] = value; }
		}

		[ConfigurationProperty("senderEmailAddress", IsRequired = true)]
		public string SenderEmailAddress
		{
			get { return (string)base["senderEmailAddress"]; }
			set { base["senderEmailAddress"] = value; }
		}

		[ConfigurationProperty("", IsDefaultCollection = true)]
		public EmailServiceProviderCollection EmailServiceProviders
		{
			get
			{
				return (EmailServiceProviderCollection)base[""];
			}
		}

		public EmailServiceProviderCollectionItem GetActiveProvider()
		{
			return EmailServiceProviders.GetItem(ActiveProviderName);
		}
	}
}
