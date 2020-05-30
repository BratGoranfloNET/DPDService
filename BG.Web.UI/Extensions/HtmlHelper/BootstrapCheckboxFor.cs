using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BG.Web.UI.Extensions
{
	/// <summary>
	/// Partial @Html extensions.
	/// </summary>
	public static partial class HtmlHelperExtensions
	{
		/// <summary>
		/// Renders a checkbox without an associated hidden field to avoid conflict with bootstrap CSS rules.
		/// </summary>
		public static MvcHtmlString BootstrapCheckboxFor<TModel>(this HtmlHelper<TModel> @this, Expression<Func<TModel, bool>> expression, object htmlAttributes = null)
		{
			var pattern = "(<.*input.*type=\"checkbox\".*>)(<.*input.*type=\"hidden\".*>)";

			var input = @this.CheckBoxFor(expression, htmlAttributes).ToString();

			var output = Regex.Replace(input, pattern, "$1");

			return new MvcHtmlString(output);
		}
	}
}
