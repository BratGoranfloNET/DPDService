using BG.Services.Image;
using System.Web.Mvc;

namespace BG.Web.UI.Extensions
{
	/// <summary>
	/// Partial @Url extensions.
	/// </summary>
	public static partial class UrlHelperExtensions
	{
		public static string Image(this UrlHelper @this, string blobFileName, string seoLabel, int? width = null, int? height = null)
		{
			var imageServices = DependencyResolver.Current.GetService<IImageService>();

			return imageServices.BuildUrl(blobFileName, seoLabel, width, height);
		}
	}
}
