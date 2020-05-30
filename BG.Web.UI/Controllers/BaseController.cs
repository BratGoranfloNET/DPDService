using BG.Core.Principal;
using BG.Web.Feedback;
using BG.Web.UI.Models;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BG.Web.UI.Extensions;
using BG.Web.Globalization;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Base controller.
	/// </summary>
	public abstract class BaseController : Controller
	{
		/// <summary>
		/// Feedback messages context manager.
		/// </summary>
		public FeedbackContext Feedback
		{
			get
			{
				string key = nameof(FeedbackContext);

				var manager = TempData.Peek(key) as FeedbackContext;

				if (manager == null)
				{
					manager = new FeedbackContext();
					TempData.Add(key, manager);
				}

				return manager;
			}
		}

		/// <summary>
		/// Globalization context manager.
		/// </summary>
		public GlobalizationContext Globalization { get; private set; }

		/// <summary>
		/// Get custom user principal.
		/// </summary>
		public new CorePrincipal User => new CorePrincipal(base.User);

		/// <summary>
		/// Configure globalization cookies and current thread culture information.
		/// </summary>
		public void ConfigureGlobalizationContext(HttpContextBase httpContext, string regionCulture = null, string languageCulture = null, string timeZoneId = null)
		{
			var regionCookieName = GlobalizationContext.RegionCultureCookieName;
			var languageCookieName = GlobalizationContext.LanguageCultureCookieName;
			var timeZoneCookieName = GlobalizationContext.TimeZoneIdCookieName;

			var regionCookie = httpContext.GetCookie(regionCookieName);
			var languageCookie = httpContext.GetCookie(languageCookieName);
			var timeZoneCookie = httpContext.GetCookie(timeZoneCookieName);

			/*
			 * Region culture
			 */
			regionCulture = regionCulture ?? regionCookie?.Value ?? User.RegionCulture;
			httpContext.SetCookie(regionCookieName, regionCulture);

			/*
			 * Language culture
			 */
			languageCulture = languageCulture ?? languageCookie?.Value ?? User.LanguageCulture;
			httpContext.SetCookie(languageCookieName, languageCulture);

			/*
			 * Time zone
			 */
			timeZoneId = timeZoneId ?? timeZoneCookie?.Value ?? User.TimeZone;
			httpContext.SetCookie(timeZoneCookieName, timeZoneId);

			/*
			 * Set globalization context.
			 */
			var regionCultureInfo = CultureInfo.GetCultureInfo(regionCulture);
			var languageCultureInfo = CultureInfo.GetCultureInfo(languageCulture);
			var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

			Globalization = new GlobalizationContext(regionCultureInfo, languageCultureInfo, timeZoneInfo);

			httpContext.Items[nameof(GlobalizationContext)] = Globalization;

			/*
			 * Set threads.
			 */
			Thread.CurrentThread.CurrentCulture = regionCultureInfo;
			Thread.CurrentThread.CurrentUICulture = languageCultureInfo;
		}

		/// <summary>
		/// Initialize controller and culture.
		/// </summary>
		protected override void Initialize(System.Web.Routing.RequestContext requestContext)
		{
			base.Initialize(requestContext);

			ConfigureGlobalizationContext(requestContext.HttpContext);
		}

		/// <summary>
		/// Build and return the error view/json.
		/// </summary>
		[NonAction]
		public ActionResult ErrorResult(HttpStatusCode statusCode, string message = null, Exception exception = null)
		{
			var code = statusCode.ChangeType<string>();
			var isDebug = HttpContext.IsDebuggingEnabled;
			var errorViewModel = new ErrorViewModel(statusCode, errorMessage: message);

			Response.StatusCode = errorViewModel.Code;

			if (!Request.IsAjaxRequest())
				return View(nameof(ErrorsController.Global), errorViewModel);

			ModelState.AddModelError(code, errorViewModel.Message);

			return JsonError(ModelState);
		}

		/// <summary>
		/// Handles json errors.
		/// </summary>
		[NonAction]
		public JsonResult JsonError(ModelStateDictionary modelState, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
		{
			Response.StatusCode = (int)statusCode;

			return Json(modelState);
		}

		/// <summary>
		/// Render a view and returns its contents.
		/// </summary>
		[NonAction]
		public string RenderViewToString(string viewName, string masterName = null, object model = null)
		{
			ViewData.Model = model;

			using (var sw = new StringWriter())
			{
				var viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, masterName);
				var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

				viewResult.View.Render(viewContext, sw);
				viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

				return sw.GetStringBuilder().ToString();
			}
		}

		/// <summary>
		/// Render a partial view and returns its contents.
		/// </summary>
		[NonAction]
		public string RenderPartialViewToString(string viewName, object model = null)
		{
			ViewData.Model = model;

			using (var sw = new StringWriter())
			{
				var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
				var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

				viewResult.View.Render(viewContext, sw);
				viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

				return sw.GetStringBuilder().ToString();
			}
		}

		/// <summary>
		/// Custom json result.
		/// </summary>
		protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding)
		{
			return new DotJsonResult()
			{
				Data = data,
				ContentType = contentType,
				ContentEncoding = contentEncoding
			};
		}

		/// <summary>
		/// Custom json result.
		/// </summary>
		protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return new DotJsonResult()
			{
				Data = data,
				ContentType = contentType,
				ContentEncoding = contentEncoding,
				JsonRequestBehavior = behavior
			};
		}
	}
}
