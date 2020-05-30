using System.Web.Mvc;

namespace BG.Web
{
	/// <summary>
	/// Platform conventions aware view engine.
	/// </summary>
	public class DotRazorViewEngine : RazorViewEngine
	{
		public DotRazorViewEngine()
		{
			// I.e.: "~/Views/Customers/Index.cshtml"
			//       "~/Views/Terms.cshtml"
			var viewSeachPaths = new string[] {
				"~/Views/{1}/{0}.cshtml",
				"~/Views/{0}.cshtml"
			};

			ViewLocationFormats = viewSeachPaths;
			PartialViewLocationFormats = viewSeachPaths;
		}
	}
}