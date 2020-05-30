using NLog.LayoutRenderers;
using Owin;
using BG.Core.Context;
using BG.Core.Entities;
using BG.Web.Configs;
using SimpleInjector;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize NLog system.
		/// </summary>
		public void ConfigureLogger(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container)
		{
			// Context realm
			LayoutRenderer.Register("realm", (logEvent) => Realm.BG.GetDisplayName());

			// Context user id
			LayoutRenderer.Register("userId", (logEvent) => {

				var context = container.GetInstance<IWebContext>();

				if (context == null || context.User.Id <= 0)
					return "Anonymous";

				return context.User.Id.ToString();
			});
		}
	}
}