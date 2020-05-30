using BG.Core.Principal;

namespace BG.Core.Context
{
	/// <summary>
	/// Current web request context inteface.
	/// </summary>
	public interface IWebContext
	{
		/// <summary>
		/// Get the current principal.
		/// </summary>
		CorePrincipal User { get; }
	}
}
