using System.IO;

namespace BG.Services.Image
{
	/// <summary>
	/// Partial image service implementation.
	/// </summary>
	public partial class ImageService
	{
		/// <summary>
		/// Get the image stream from its virtual path.
		/// </summary>
		public Stream GetStream(string virtualPath)
		{
			var relativePath = _storagePathBuilder.BuildRelativePath(virtualPath);

			var stream = _imageStorageProvider.GetStream(relativePath);

			if (stream != Stream.Null)
				return stream;

			return new DefaultImage(virtualPath, "#008c95", "#FFFFFF");
		}
	}
}
