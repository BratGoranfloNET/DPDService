using System.Collections.Generic;

namespace BG.Core.Providers
{
	/// <summary>
	/// Base provider parameters collection.
	/// </summary>
	public abstract class ProviderParameters : Dictionary<string, object>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public ProviderParameters(Dictionary<string, object> parameters) : base(parameters)
		{
		}

		/// <summary>
		/// Gets the value associated with the specified parameter key.
		/// </summary>
		public T GetValue<T>(string parameterKey, T defaultValue = default(T))
		{
			object value = null;

			if (TryGetValue(parameterKey, out value))
				return value.ChangeType<T>(defaultValue);

			return defaultValue;
		}
	}
}
