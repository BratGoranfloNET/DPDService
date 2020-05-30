using BG.Core.Principal;
using BG.Web.UI.Controllers;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Routing;

namespace BG.Web.UI.Attributes
{
	/// <summary>
	/// Prevent actions to be executed when the user screen is locked
	/// (Unless the action is decorated with the <see cref="LockScreenAllowedAttribute"/> attribute).
	/// </summary>
	public class LockScreenAgentAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var actionAllowed = filterContext.ActionDescriptor.GetCustomAttributes(typeof(LockScreenAllowedAttribute), false).Any();

			if (!actionAllowed)
			{
				var user = filterContext.HttpContext.User as ClaimsPrincipal;

				var screenLocked = user?.FindFirst(CorePrincipal.ClaimTypes.ScreenLocked)?.Value.ChangeType<bool>() ?? false;

				if (screenLocked)
				{
					filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
					{
						{ "action", nameof(UsersController.LockScreen) },
						{ "controller", nameof(UsersController).RemoveControllerSuffix() }
					});
				}
			}
		}
	}
}
