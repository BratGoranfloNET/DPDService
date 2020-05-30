using BG.Web.UI.Attributes;
using System;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial errors controller.
	/// </summary>
	public partial class ErrorsController
	{
		/// <summary>
		/// Global error handling action.
		/// <para>The route for this method is defined in the global.asax file.</para>
		/// </summary
		[LockScreenAllowed]
		public ActionResult Global(int? code)
		{
			// Set the code
			code = code ?? 500;

			// Get unhandled exception
			// Can be set from controllers or in global.asax
			var exception = RouteData.Values["ex"] as Exception;

			// Return result from base
			return ErrorResult((HttpStatusCode)code, exception: exception);
		}
	}
}
