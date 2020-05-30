﻿using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ContactsIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/contacts/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ContactsIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/contacts/index.js");
		}
	}
}
