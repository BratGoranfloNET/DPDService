using ImageResizer.Plugins;
using BG.Services.Image;
using System.IO;

namespace BG.Web.Providers
{
	/// <summary>
	/// Virtual image file for resizing functionalities.
	/// </summary>
	public class ImageVirtualFile : IVirtualFile
	{
		private string _virtualPath = null;
		private IImageService _imageService = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ImageVirtualFile(string virtualPath, IImageService imageService)
		{
			_virtualPath = virtualPath;
			_imageService = imageService;
		}

		/// <summary>
		/// Virtual path of the requested image.
		/// </summary>
		public string VirtualPath => _virtualPath;

		/// <summary>
		/// Data stream from the requested image.
		/// </summary>
		public Stream Open() => _imageService.GetStream(_virtualPath);
	}
}
