using System.Collections.Generic;

namespace BG.Core.Providers
{
	/// <summary>
	/// E-Mail provider parameters collection.
	/// </summary>
	public class EmailProviderParameters : ProviderParameters
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public EmailProviderParameters(Dictionary<string, object> parameters) : base(parameters)
		{
		}
	}
}
