using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BG.Web
{
	/// <summary>
	/// Default JSON serialization settings.
	/// </summary>
	public class DotJsonSerializationSettings : JsonSerializerSettings
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public DotJsonSerializationSettings()
		{
			NullValueHandling = NullValueHandling.Ignore;
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
			ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
	}
}
