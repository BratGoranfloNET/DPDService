using SimpleInjector.Advanced;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;

namespace BG.Web.DependencyInjection
{
	/// <summary>
	/// Allow explicit property injection on members marked with the <see cref="ImportAttribute"/> class.
	/// <para>This kind of injection allows the container.Verify() method to detect injection errors.</para>
	/// </summary>
	public class ImportPropertySelectionBehavior : IPropertySelectionBehavior
	{
		/// <summary>
		/// Determines whether a property should be injected by the container upon creation of its type.
		/// </summary>
		public bool SelectProperty(Type type, PropertyInfo prop)
		{
			return prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
		}
	}
}
