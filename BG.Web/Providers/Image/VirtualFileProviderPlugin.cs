using ImageResizer.Configuration;
using ImageResizer.Plugins;
using BG.Services.Image;
using System.Collections.Specialized;
using System.Web;

namespace BG.Web.Providers
{
	/// <summary>
	/// Provide virtual file instances to be processed by the image resizer library.
	/// </summary>
	public class VirtualFileProviderPlugin : IPlugin, IVirtualImageProvider
	{
		private IImageService _imageService = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public VirtualFileProviderPlugin(IImageService imageService)
		{
			_imageService = imageService;
		}

		/// <summary>
		/// Plugin installer method as recommended by the library authors.
		/// </summary>
		public IPlugin Install(Config config)
		{
			config.Plugins.add_plugin(this);

			return this;
		}

		/// <summary>
		/// Plugin uninstaller method as recommended by the library authors.
		/// </summary>
		public bool Uninstall(Config config)
		{
			config.Plugins.remove_plugin(this);

			return true;
		}

		/// <summary>
		/// Check if the requested file exists, based on its virtual path.
		/// </summary>
		public bool FileExists(string virtualPath, NameValueCollection queryString) => MimeMapping.GetMimeMapping(virtualPath).Contains("image");

		/// <summary>
		/// Return the corresponding virtual file instance based on the requested file virtual path.
		/// </summary>
		public IVirtualFile GetFile(string virtualPath, NameValueCollection queryString) => new ImageVirtualFile(virtualPath, _imageService);
	}
}
