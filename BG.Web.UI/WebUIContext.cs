using BG.Core.Context;
using BG.Core.Principal;

namespace BG.Web.UI
{
	/// <summary>
	/// Current request context implementation.
	/// </summary>
	public class WebUIContext : IWebContext
	{
		CorePrincipal _principal = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public WebUIContext(CorePrincipal principal = null)
		{
			_principal = principal;
		}

		/// <summary>
		/// Get the current user.
		/// </summary>
		public CorePrincipal User => _principal;
	}
}