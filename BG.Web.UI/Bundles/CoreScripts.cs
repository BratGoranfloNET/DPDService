using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CoreScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/core/scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CoreScripts() : base(BundleVirtualPath)
		{


            Include("~/Scripts/knockout-3.2.0.js");
            Include("~/Scripts/knockout.custom.js");




            // JQuery
            Include("~/assets/vendor/jquery/jquery.js");

			// JQuery cookie
			Include("~/assets/vendor/jquery-cookie/jquery-cookie.js");

			Include("~/scripts/__config_cookies.js");

			// Browser mobile
			Include("~/assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js");

			// Bootstrap
			Include("~/assets/vendor/bootstrap/js/bootstrap.js");

			// Nano scroller
			Include("~/assets/vendor/nanoscroller/nanoscroller.js");

			// Max length
			Include("~/assets/vendor/bootstrap-maxlength/bootstrap-maxlength.js");

			// Confirmation
			Include("~/assets/vendor/bootstrap-confirmation/bootstrap-confirmation.js");

			// Auto size
			Include("~/assets/vendor/autosize/autosize.js");

			// Color picker
			Include("~/assets/vendor/bootstrap-colorpicker/js/bootstrap-colorpicker.js");

			// Magnific popup
			Include("~/assets/vendor/magnific-popup/jquery.magnific-popup.js");

			// Placeholder
			Include("~/assets/vendor/jquery-placeholder/jquery-placeholder.js");

			// Jquery UI
			Include("~/assets/vendor/jquery-ui/jquery-ui.js");
			Include("~/assets/vendor/jqueryui-touch-punch/jqueryui-touch-punch.js");

			// Notifications
			Include("~/assets/vendor/pnotify/pnotify.custom.js");

			// Progress
			Include("~/assets/vendor/nprogress/nprogress.js");

			// Select 2
			Include("~/assets/vendor/select2/js/select2.js");

			// Maked input
			Include("~/assets/vendor/jquery-maskedinput/jquery.maskedinput.js");

			// Idle timer
			Include("~/assets/vendor/jquery-idletimer/idle-timer.js");

			// Globalization
			Include("~/Scripts/cldr.js");
			Include("~/Scripts/cldr/event.js");
			Include("~/Scripts/cldr/supplemental.js");
			Include("~/Scripts/globalize.js");
			Include("~/Scripts/globalize/number.js");
			Include("~/Scripts/globalize/plural.js");
			Include("~/Scripts/globalize/currency.js");
			Include("~/Scripts/globalize/date.js");
			Include("~/Scripts/globalize/message.js");
			Include("~/Scripts/globalize/relative-time.js");
			Include("~/Scripts/globalize/unit.js");
			Include("~/scripts/__config_globalization.js");

			// Date pickers and it's available locales
			Include("~/assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js");
			this.IncludeLocaleScripts("~/assets/vendor/bootstrap-datepicker/locales/bootstrap-datepicker.{0}.min.js");
			Include("~/scripts/__config_datepicker.js");

			// Time picker
			Include("~/assets/vendor/bootstrap-timepicker/bootstrap-timepicker.js");
			Include("~/scripts/__config_timepicker.js");

			// Validation
			Include("~/Scripts/jquery.validate.min.js");
			Include("~/Scripts/__config_jquery_validate.js");
			Include("~/Scripts/jquery.validate.unobtrusive.min.js");
			Include("~/Scripts/__config_jquery_validate_unobtrusive.js");
		}
	}
}
