using System.Web.Mvc;

namespace BG.Web.UI.Attributes
{
	/// <summary>
	/// Attribute that decorate actions that can be executed when the user screen is locked.
	/// </summary>
	public class LockScreenAllowedAttribute : ActionFilterAttribute
	{
	}
}
