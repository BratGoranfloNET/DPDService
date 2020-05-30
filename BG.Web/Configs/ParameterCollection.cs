using System;
using System.Configuration;

namespace BG.Web.Configs
{
	/// <summary>
	/// Represent a parameter collection from the app configuration file.
	/// </summary>
	[ConfigurationCollection(typeof(ParameterCollectionItem), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class ParameterCollection : ConfigurationElementCollection
	{
		/// <summary>
		/// Create a new parameter item.
		/// </summary>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ParameterCollectionItem();
		}

		/// <summary>
		/// Get a parameter item key from parameters collection.
		/// </summary>
		protected override object GetElementKey(ConfigurationElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			return ((ParameterCollectionItem)element).Key;
		}
	}
}
